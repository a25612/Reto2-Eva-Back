using MySql.Data.MySqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pisicna_Back.Repositories
{
    public class ServiciosRepository : IServiciosRepository
    {
        private readonly string _connectionString;

        public ServiciosRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Servicio>> GetAllAsync()
        {
            var servicios = new List<Servicio>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT s.Id, s.Nombre, s.Precio, GROUP_CONCAT(sc.IdCentro) AS Centros FROM Servicios s LEFT JOIN Servicios_Centros sc ON s.Id = sc.IdServicio GROUP BY s.Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var servicio = new Servicio(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                Convert.ToDecimal(reader["Precio"]),
                                reader["Centros"].ToString().Split(',').Select(int.Parse).ToList()
                            );

                            servicios.Add(servicio);
                        }
                    }
                }
            }
            return servicios;
        }

        public async Task<Servicio?> GetByIdAsync(int id)
        {
            Servicio? servicio = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT s.Id, s.Nombre, s.Precio, GROUP_CONCAT(sc.IdCentro) AS Centros FROM Servicios s LEFT JOIN Servicios_Centros sc ON s.Id = sc.IdServicio WHERE s.Id = @Id GROUP BY s.Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            servicio = new Servicio(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                Convert.ToDecimal(reader["Precio"]),
                                reader["Centros"].ToString().Split(',').Select(int.Parse).ToList()
                            );
                        }
                    }
                }
            }
            return servicio;
        }

        public async Task AddAsync(Servicio servicio)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Servicios (Nombre, Precio) VALUES (@Nombre, @Precio); SELECT LAST_INSERT_ID();";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    command.Parameters.AddWithValue("@Precio", servicio.Precio);
                    
                    int servicioId = Convert.ToInt32(await command.ExecuteScalarAsync());
                    
                    foreach (var idCentro in servicio.IdsCentros)
                    {
                        string centroQuery = "INSERT INTO Servicios_Centros (IdServicio, IdCentro) VALUES (@IdServicio, @IdCentro)";
                        using (var centroCommand = new MySqlCommand(centroQuery, connection))
                        {
                            centroCommand.Parameters.AddWithValue("@IdServicio", servicioId);
                            centroCommand.Parameters.AddWithValue("@IdCentro", idCentro);
                            await centroCommand.ExecuteNonQueryAsync();
                        }
                    }
                }
            }
        }

        public async Task UpdateAsync(Servicio servicio)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Servicios SET Nombre = @Nombre, Precio = @Precio WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", servicio.Id);
                    command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    command.Parameters.AddWithValue("@Precio", servicio.Precio);
                    await command.ExecuteNonQueryAsync();
                }

                string deleteCentrosQuery = "DELETE FROM Servicios_Centros WHERE IdServicio = @IdServicio";
                using (var deleteCommand = new MySqlCommand(deleteCentrosQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@IdServicio", servicio.Id);
                    await deleteCommand.ExecuteNonQueryAsync();
                }

                foreach (var idCentro in servicio.IdsCentros)
                {
                    string insertCentroQuery = "INSERT INTO Servicios_Centros (IdServicio, IdCentro) VALUES (@IdServicio, @IdCentro)";
                    using (var insertCommand = new MySqlCommand(insertCentroQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@IdServicio", servicio.Id);
                        insertCommand.Parameters.AddWithValue("@IdCentro", idCentro);
                        await insertCommand.ExecuteNonQueryAsync();
                    }
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string deleteCentrosQuery = "DELETE FROM Servicios_Centros WHERE IdServicio = @IdServicio";
                using (var command = new MySqlCommand(deleteCentrosQuery, connection))
                {
                    command.Parameters.AddWithValue("@IdServicio", id);
                    await command.ExecuteNonQueryAsync();
                }

                string query = "DELETE FROM Servicios WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

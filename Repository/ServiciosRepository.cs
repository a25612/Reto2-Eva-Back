using MySql.Data.MySqlClient;
using Models;

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

                string query = "SELECT Id, Nombre, Precio FROM Servicios";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var servicio = new Servicio(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                Convert.ToDecimal(reader["Precio"])
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

                string query = "SELECT Id, Nombre, Precio FROM Servicios WHERE Id = @Id";
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
                                Convert.ToDecimal(reader["Precio"])
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

                string query = "INSERT INTO Servicios (Nombre, Precio) VALUES (@Nombre, @Precio)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", servicio.Nombre);
                    command.Parameters.AddWithValue("@Precio", servicio.Precio);

                    await command.ExecuteNonQueryAsync();
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
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Servicios WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task InicializarDatosAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @"";

                using (var command = new MySqlCommand(query, connection))
                {

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

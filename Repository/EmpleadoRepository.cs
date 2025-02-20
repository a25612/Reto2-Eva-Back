using MySql.Data.MySqlClient;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pisicna_Back.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly string _connectionString;

        public EmpleadoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Empleado>> GetAllAsync()
        {
            var empleados = new List<Empleado>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, DNI, JornadaTotalHoras, Username, Password, Rol, IdCentro FROM Empleados";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var empleado = new Empleado(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                Convert.ToInt32(reader["JornadaTotalHoras"]),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                Convert.ToInt32(reader["IdCentro"])
                            );
                            empleados.Add(empleado);
                        }
                    }
                }
            }
            return empleados;
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            Empleado? empleado = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, DNI, JornadaTotalHoras, Username, Password, Rol, IdCentro FROM Empleados WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            empleado = new Empleado(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                Convert.ToInt32(reader["JornadaTotalHoras"]),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                Convert.ToInt32(reader["IdCentro"])
                            );
                        }
                    }
                }
            }
            return empleado;
        }

        public async Task AddAsync(Empleado empleado)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Empleados (Nombre, DNI, JornadaTotalHoras, Username, Password, Rol, IdCentro) VALUES (@Nombre, @DNI, @JornadaTotalHoras, @Username, @Password, 'EMPLEADO', @IdCentro)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@DNI", empleado.DNI);
                    command.Parameters.AddWithValue("@JornadaTotalHoras", empleado.JornadaTotalHoras);
                    command.Parameters.AddWithValue("@Username", empleado.Username);
                    command.Parameters.AddWithValue("@Password", empleado.Password);
                    command.Parameters.AddWithValue("@IdCentro", empleado.IdCentro);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Empleados SET Nombre = @Nombre, DNI = @DNI, JornadaTotalHoras = @JornadaTotalHoras, Username = @Username, Password = @Password, IdCentro = @IdCentro WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", empleado.Id);
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@DNI", empleado.DNI);
                    command.Parameters.AddWithValue("@JornadaTotalHoras", empleado.JornadaTotalHoras);
                    command.Parameters.AddWithValue("@Username", empleado.Username);
                    command.Parameters.AddWithValue("@Password", empleado.Password);
                    command.Parameters.AddWithValue("@IdCentro", empleado.IdCentro);
                    
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Empleados WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<Empleado?> GetByUsernameAndPasswordAsync(string username, string password)
        {
            Empleado? empleado = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, DNI, JornadaTotalHoras, Username, Password, IdCentro FROM Empleados WHERE Username = @Username AND Password = @Password";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            empleado = new Empleado(
                                Convert.ToInt32(reader["Id"]),
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                Convert.ToInt32(reader["JornadaTotalHoras"]),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                Convert.ToInt32(reader["IdCentro"])
                            );
                        }
                    }
                }
            }
            return empleado;
        }
    }
}

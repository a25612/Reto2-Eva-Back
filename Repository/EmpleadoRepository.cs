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

                string query = "SELECT Id, Nombre, DNI, JornadaTotalHoras, Rol FROM Empleados";  // Añadido el campo 'Rol' aquí
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var empleado = new Empleado(
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                Convert.ToInt32(reader["JornadaTotalHoras"])
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

                string query = "SELECT Id, Nombre, DNI, JornadaTotalHoras, Rol FROM Empleados WHERE Id = @Id";  // Añadido el campo 'Rol' aquí
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            empleado = new Empleado(
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                Convert.ToInt32(reader["JornadaTotalHoras"])
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

                string query = "INSERT INTO Empleados (Nombre, DNI, JornadaTotalHoras, Rol) VALUES (@Nombre, @DNI, @JornadaTotalHoras, 'EMPLEADO')";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@DNI", empleado.DNI);
                    command.Parameters.AddWithValue("@JornadaTotalHoras", empleado.JornadaTotalHoras);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Empleados SET Nombre = @Nombre, DNI = @DNI, JornadaTotalHoras = @JornadaTotalHoras WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", empleado.Id);
                    command.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    command.Parameters.AddWithValue("@DNI", empleado.DNI);
                    command.Parameters.AddWithValue("@JornadaTotalHoras", empleado.JornadaTotalHoras);

                    // No actualizamos 'Rol', porque siempre debe ser 'EMPLEADO'
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

        public async Task InicializarDatosAsync()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = @""; // Aquí puedes definir datos iniciales si es necesario

                using (var command = new MySqlCommand(query, connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

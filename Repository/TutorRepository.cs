using MySql.Data.MySqlClient;
using Models;

namespace Pisicna_Back.Repositories
{
    public class TutorRepository : ITutorRepository
    {
        private readonly string _connectionString;

        public TutorRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Tutor>> GetAllAsync()
        {
            var tutores = new List<Tutor>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, DNI, Email, Username, Password, Activo FROM Tutores";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var tutor = new Tutor(
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                reader["Email"].ToString(),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                reader["Activo"].ToString() == "S"
                            );

                            tutores.Add(tutor);
                        }
                    }
                }
            }
            return tutores;
        }

        public async Task<Tutor?> GetByIdAsync(int id)
        {
            Tutor? tutor = null;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "SELECT Id, Nombre, DNI, Email, Username, Password, Activo FROM Tutores WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            tutor = new Tutor(
                                reader["Nombre"].ToString(),
                                reader["DNI"].ToString(),
                                reader["Email"].ToString(),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                reader["Activo"].ToString() == "S"
                            );
                        }
                    }
                }
            }
            return tutor;
        }

        public async Task AddAsync(Tutor tutor)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "INSERT INTO Tutores (Nombre, DNI, Email, Username, Password, Activo) VALUES (@Nombre, @DNI, @Email, @Username, @Password, @Activo)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", tutor.Nombre);
                    command.Parameters.AddWithValue("@DNI", tutor.DNI);
                    command.Parameters.AddWithValue("@Email", tutor.Email);
                    command.Parameters.AddWithValue("@Username", tutor.Username);
                    command.Parameters.AddWithValue("@Password", tutor.Password);
                    command.Parameters.AddWithValue("@Activo", tutor.Activo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateAsync(Tutor tutor)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "UPDATE Tutores SET Nombre = @Nombre, DNI = @DNI, Email = @Email, Username = @Username, Password = @Password, Activo = @Activo WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", tutor.Id);
                    command.Parameters.AddWithValue("@Nombre", tutor.Nombre);
                    command.Parameters.AddWithValue("@DNI", tutor.DNI);
                    command.Parameters.AddWithValue("@Email", tutor.Email);
                    command.Parameters.AddWithValue("@Username", tutor.Username);
                    command.Parameters.AddWithValue("@Password", tutor.Password);
                    command.Parameters.AddWithValue("@Activo", tutor.Activo);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = "DELETE FROM Tutores WHERE Id = @Id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

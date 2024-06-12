using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarrWarehouseAppWPF
{
    public class DatabaseManager
    {
        public string connectionString { get; private set; }

        public DatabaseManager(string server, string database, string username, string password)
        {
            connectionString = $"Server=NOUT;Database=CarWarehouseAppWPF;User Id=NAMI;Password=namissms;";
        }

        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Password FROM Employees WHERE Username = @Username";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        string hashedPassword = result.ToString();
                        return VerifyPassword(password, hashedPassword);
                    }
                }
            }
            return false;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            // Здесь должно быть сравнение хэшей, если вы используете хэширование
            // Пример для простого сравнения (не безопасно для реального использования):
            return password == hashedPassword;
        }
        public void AddCar(Car car)
        {
            // Логика добавления машины в базу данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Cars (Brand, Model, Year) VALUES (@Brand, @Model, @Year)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", car.Brand);
                    command.Parameters.AddWithValue("@Model", car.Model);
                    command.Parameters.AddWithValue("@Year", car.Year);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteCar(int carId)
        {
            // Логика удаления машины из базы данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Cars WHERE Id = @CarId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CarId", carId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCar(Car updatedCar)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cars SET Brand = @Brand, Model = @Model, Year = @Year WHERE Id = @CarId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Brand", updatedCar.Brand);
                    command.Parameters.AddWithValue("@Model", updatedCar.Model);
                    command.Parameters.AddWithValue("@Year", updatedCar.Year);
                    command.Parameters.AddWithValue("@CarId", updatedCar.Id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Car> GetCars()
        {
            List<Car> cars = new List<Car>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cars";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Car car = new Car
                            {
                                Id = (int)reader["Id"],
                                Brand = (string)reader["Brand"],
                                Model = (string)reader["Model"],
                                Year = (int)reader["Year"]
                            };
                            cars.Add(car);
                        }
                    }
                }
            }
            return cars;
        }
    }


    public class Employee
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}

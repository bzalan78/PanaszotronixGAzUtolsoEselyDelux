using MySqlConnector;
using Panasz.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panasz.database
{
    internal class DatabaseService
    {
        private static string connectionString;
        private static string table;
        private static string query_parameters;

        public static void DbConnectionCheck(string connectionString)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Sikeres a csatlakozás!!");
                    Console.WriteLine();
                    Console.WriteLine("Üdvözöl a PANASZOTRONIX G: UTOLSÓ ESÉLY DELUX");
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Sikertelen kapcsolódás");
                Console.WriteLine(ex);
            }

        }
        public static DataTable GetAllDatafromnev(string tableName, string colname, string connectionString, string diaknev)
        {
            /* using var connection = new MySqlConnection(connectionString);
             connection.Open();
             using var command = new MySqlCommand("select * from " + tableName+ " where "+diaknev+ $" like '%{diaknev}%' ");
             using var reader = command.ExecuteReader();
             var dataTable = new DataTable();

             dataTable.Load(reader);

             return dataTable;*/
            

            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = $"SELECT * FROM {tableName} WHERE {colname} LIKE @nev";

            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nev", $"%{diaknev}%");

            using var reader = command.ExecuteReader();
            var dataTable = new DataTable();

            dataTable.Load(reader);

            return dataTable;






        }

        public static DataTable GetAllData(string tableName, string connectionString)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand("select * from " + tableName, connection);

            using var reader = command.ExecuteReader();
            var dataTable = new DataTable();

            dataTable.Load(reader);

            return dataTable;

        }
        public static int DeleteById(string connectionString, string tableName, int id)
        {
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            using var command = new MySqlCommand($"delete from {tableName} where id=@id", connection);
            command.Parameters.AddWithValue("id", id);

            return command.ExecuteNonQuery();
            //1=done, 0=id nem letezik


        }
        public static void InsertUser(string tanarnev, string diaknev, string email, string telefon, string datum, string panasz, string connectionString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO panaszkonyv (tanar_neve, diak_neve, email, telefon, datum, panasz) VALUES (@tanarnev, @diaknev, @email, @telefon, @datum, @panasz)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@tanarnev", tanarnev);
                    command.Parameters.AddWithValue("@diaknev", diaknev);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@telefon", telefon);
                    command.Parameters.AddWithValue("@datum", datum);
                    command.Parameters.AddWithValue("@panasz", panasz);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olympics.Controllers
{
    public static class Partecipations
    {
        private static string connectionString { get; } = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        /// <summary>
        /// Metodo di accesso al database per popolazione comboBox non vincolate
        /// </summary>
        /// <param name="col">Nome della colonna sulla quale effettuare un SELECT DISTINCT</param>
        /// <returns></returns>
        public static List<string> GetDistinctList(string col)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT DISTINCT "+ col +" FROM athletes WHERE " + col + " IS NOT NULL ORDER BY " + col + "";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add((string)reader[col]);
                        }
                    }
                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        /// <summary>
        /// Metodo di accesso al database per popolazione della comboBox vincolata
        /// </summary>
        /// <param name="Game">Parametro per il quale si crea il vincolo per logica SELECT DISTINCT, inserito in condizione WHERE</param>
        /// <returns></returns>
        public static List<string> GetDistinctSport(string Game)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT DISTINCT Sport FROM Athletes WHERE Games = @Game ORDER BY Sport";
                    cmd.Parameters.AddWithValue("@Game", Game);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add((string)reader["Sport"]);
                        }
                    }
                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }


        public static List<string> GetDistinctEvent(string Sport)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT DISTINCT Event FROM Athletes WHERE Sport = @Sport ORDER BY Event";
                    cmd.Parameters.AddWithValue("@Sport", Sport);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add((string)reader["Event"]);
                        }
                    }
                    return retVal;

                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

    }
}

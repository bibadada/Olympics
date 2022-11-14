using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Olympics.Models;

namespace Olympics.Controllers
{
    public static class Partecipations
    {
        /// <summary>
        /// Stringa di connessione al DB
        /// </summary>
        private static string connectionString { get; } = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

        /// <summary>
        /// Metodo di accesso al database per popolazione comboBox non vincolate
        /// </summary>
        /// <param name="col">Nome della colonna sulla quale effettuare un SELECT DISTINCT svincolata</param>
        /// <returns>Lista di stringhe della colonna</returns>
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
        /// Metodo di accesso al database per popolazione della comboBox vincolata Sport
        /// </summary>
        /// <param name="Game">Parametro per il quale si crea il vincolo per logica SELECT DISTINCT, inserito in condizione WHERE</param>
        /// <returns>Lista di stringhe della colonna</returns>
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

        /// <summary>
        /// Metodo di accesso al database per popolazione della comboBox vincolata Event
        /// </summary>
        /// <param name="Sport">Parametro per il quale si crea il vincolo per logica SELECT DISTINCT, inserito in condizione WHERE</param>
        /// <returns>Lista di stringhe della colonna</returns>
        public static List<string> GetDistinctEvent(string Sport, string Games)
        {
            List<string> retVal = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = @"SELECT DISTINCT Event FROM Athletes WHERE Sport = @Sport AND Games = @Games ORDER BY Event";
                    cmd.Parameters.AddWithValue("@Sport", Sport);
                    cmd.Parameters.AddWithValue("@Games", Games);
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

        /// <summary>
        /// Metodo di accesso al database che ricerca in base ai parametri passati e ne esegue l'offset e il fetch in base ai parametri Pagina e RighePagina, ignora i null
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Games"></param>
        /// <param name="Sport"></param>
        /// <param name="Event"></param>
        /// <param name="Medal"></param>
        /// <param name="Pagina"></param>
        /// <param name="RighePagina"></param>
        /// <returns>Lista di Partecipation</returns>
        public static List<Partecipation> GetPartecipations(string Name, string Sex, string Games, string Sport, string Event, string Medal, int Pagina, int RighePagina)
        {
            List<Partecipation> retVal = new List<Partecipation>();
            if (Name == null)
                Name = "%";
            Pagina--;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = BuildCommand(Name, Sex, Games, Sport, Event, Medal, false, Pagina, RighePagina);
                    cmd.Connection = connection;
                    
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            retVal.Add(new Partecipation
                            {
                                
                                Id = (long)reader["Id"],
                                IdAthlete = reader.IsDBNull(reader.GetOrdinal("IdAthlete")) ? null : (long?)reader["IdAthlete"],
                                Name = (string)reader["Name"],
                                Sex = (string)reader["Sex"],
                                Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? null : (int?)reader["Age"],
                                Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? null : (int?)reader["Height"],
                                Weight = reader.IsDBNull(reader.GetOrdinal("Weight")) ? null : (int?)reader["Weight"],
                                NOC = (string)reader["NOC"],
                                Games = (string)reader["Games"],
                                Year = reader.IsDBNull(reader.GetOrdinal("Year")) ? null : (int?)reader["Year"],
                                Season = (string)reader["Season"],
                                City = (string)reader["City"],
                                Sport = (string)reader["Sport"],
                                Event = (string)reader["Event"],
                                Medal = reader.IsDBNull(reader.GetOrdinal("Medal")) ? null : (string)reader["Medal"]
                                
                            });

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
        /// Metodo di accesso al database che conta le occorrenze filtrando per i parametri passati, ignora i null
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Sex"></param>
        /// <param name="Games"></param>
        /// <param name="Sport"></param>
        /// <param name="Event"></param>
        /// <param name="Medal"></param>
        /// <returns>numero di occorrenze -> SQL:"Count(*)"</returns>
        public static int GetNumberPartecipations(string Name, string Sex, string Games, string Sport, string Event, string Medal)
        {
            if (Name == null)
                Name = "%";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = BuildCommand(Name, Sex, Games, Sport, Event, Medal, true);
                    cmd.Connection = connection;
                    return (int)cmd.ExecuteScalar();

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }



        private static SqlCommand BuildCommand(string Name, string Sex, string Games, string Sport, string Event, string Medal, bool isCounter, int Pagina = 0, int RighePagina = 0)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM Athletes WHERE (Name LIKE @Name) ";
            cmd.Parameters.AddWithValue("@Name", "%" + Name + "%");

            if (Sex != null)
            {
                cmd.CommandText += " AND (Sex = @Sex)";
                cmd.Parameters.AddWithValue("@Sex", Sex);
            }
            if (Games != null)
            {
                cmd.CommandText += " AND (Games = @Games)";
                cmd.Parameters.AddWithValue("@Games", Games);
            }
            if (Sport != null)
            {
                cmd.CommandText += " AND (Sport = @Sport)";
                cmd.Parameters.AddWithValue("@Sport", Sport);
            }
            if (Event != null)
            {
                cmd.CommandText += " AND (Event = @Event)";
                cmd.Parameters.AddWithValue("@Event", Event);
            }
            if (Medal != null)
            {
                cmd.CommandText += " AND (Medal = @Medal)";
                cmd.Parameters.AddWithValue("@Medal", Medal);
            }
            if (isCounter)
            {
                cmd.CommandText = cmd.CommandText.Replace("*", "COUNT(*)");
                return cmd;
            }
            else
            {
                cmd.CommandText += " ORDER BY Id";
                cmd.CommandText += @"   OFFSET @off ROWS
                                            FETCH NEXT @RighePagina ROWS ONLY";
                cmd.Parameters.AddWithValue("@off", Pagina * RighePagina);
                cmd.Parameters.AddWithValue("@RighePagina", RighePagina);
                return cmd;
            }
        }

    }
}

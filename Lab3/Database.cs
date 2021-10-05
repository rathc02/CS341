/*
 * Class to handle interaction with MySQL database
 */
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Lab1
{
    public class Database : IDatabase
    {
     
        
        private static string connectionStringToDB = ConfigurationManager.ConnectionStrings["MySQLDB2"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(connectionStringToDB);
        
        
        /*
         * Method to retrieve and display entries from MySQL database
         */
        public List<Entry> GetEntries(string orderBy)
        {
            MySqlConnection con = new MySqlConnection(connectionStringToDB);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM Entries" + orderBy;
            MySqlDataReader reader = command.ExecuteReader();
            List<Entry> Display = new();
            while (reader.Read())
            {
                Entry newEntry = new Entry { Id = reader.GetInt32(0), Clue = reader.GetString(1), Answer = reader.GetString(2), Date = reader.GetString(3), Difficulty = reader.GetInt32(4) };
                Display.Add(newEntry);          
            }
            con.Close();
            return Display;
        }

        /*
         * Method to insert entry to MySQL database with unique id
         */
        public void Add(string clue, string ans, int dif, string date)
        {
            MySqlConnection con = new MySqlConnection(connectionStringToDB);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.Parameters.AddWithValue("@clue", clue);
            command.Parameters.AddWithValue("@answer", ans);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@difficulty", dif);
            command.CommandText = "INSERT INTO Entries (clue, answer, date, difficulty) VALUES (@clue, @answer, @date, @difficulty)";
            command.ExecuteNonQuery();
            con.Close();

        }

        /*
         * Method to delete entry MySQL database
         */
        public String Delete(int id)
        {
            MySqlConnection con = new MySqlConnection(connectionStringToDB);
            con.Open();
            MySqlCommand command = con.CreateCommand();
            command.Parameters.AddWithValue("@id", id);
            command.CommandText = "DELETE FROM Entries WHERE id = @id";
            command.ExecuteNonQuery();
            con.Close();
            return "Deletion success; list entries again to refresh";
            
            
        }

        /*
         * Method to edit entry in database file.
         */
        public String Edit(string clue, string ans, int dif, string date, int id)
        {
                MySqlConnection con = new MySqlConnection(connectionStringToDB);
                con.Open();
                MySqlCommand command = con.CreateCommand();
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@clue", clue);
                command.Parameters.AddWithValue("@answer", ans);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@difficulty", dif);
                command.CommandText = "UPDATE Entries SET clue = @clue, answer = @answer, date = @date, difficulty = @difficulty WHERE id = @id";
                command.ExecuteNonQuery();
                con.Close();
                return "Update success; list entries again to refresh";

        }
    }
}

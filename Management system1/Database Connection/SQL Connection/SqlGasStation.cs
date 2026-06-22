
using Management_system1.Database_Connection;
using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1.SQL_Connection
{
    class SqlGasStation : GSDatabase
    {
        string ConnectionString;
        string tableName;

        public SqlGasStation(string connectionString, string tableName)
        {
            ConnectionString = connectionString;
            this.tableName = tableName;
        }



        public bool IdInDatabase(string id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Select COUNT(1) from {tableName} where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void AddToDatabase(GasStation gasStation)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Insert into {tableName} " +
                            "VALUES {@id, @address, @numOfWorker, @profit}";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", gasStation.Id);
                    cmd.Parameters.AddWithValue("@address", gasStation.Address);
                    cmd.Parameters.AddWithValue("@numOfWorker", gasStation.NumOfWorkers);
                    cmd.Parameters.AddWithValue("@profit", gasStation.Profit);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void ViewDatabase()
        {
            Console.WriteLine($"{"GSId",-5} {"Address",-30} {"NumOfWorkers",-12} {"Profit",-6} ");
            string sql = $"Select * from {tableName}";

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cnn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = Convert.ToString(reader["Id"]);
                            string address = Convert.ToString(reader["Address"]);
                            int numOfWorkers = Convert.ToInt32(reader["NumOfWorkers"]);
                            int profit = Convert.ToInt32(reader["Profit"]);
                            Console.WriteLine($"{id,-5} {address,-30} {numOfWorkers,-12} ${profit,-6} ");
                        }
                    }
                }
            }
        }


        public void UpdateToDatabase(GasStation gasStation, string oldId)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"UPDATE {tableName} SET Id = @id, " +
                                                    "Address = @address, " +
                                                    "NumofWorkers = @numOfWorker, " +
                                                    "Profit = @profit " +
                                                    "where Id = @oldId}";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", gasStation.Id);
                    cmd.Parameters.AddWithValue("@address", gasStation.Address);
                    cmd.Parameters.AddWithValue("@numOfWorker", gasStation.NumOfWorkers);
                    cmd.Parameters.AddWithValue("@profit", gasStation.Profit);
                    cmd.Parameters.AddWithValue("@oldId", oldId);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void DeleteFromDatabase(string id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Delete from {tableName} where Id = @Id";
                    using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();
                    cmd.ExecuteNonQuery ();
                }
            }
        }
    }
}



using ManagementSystem1.Database_Connection;
using ManagementSystem1.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Management_system1.SQL_Connection
{
    public class SqlCarWashStore : CWDatabase
    {
        private readonly string ConnectionString;
        private readonly string TableName;

        public SqlCarWashStore(string connectionString, string tableName)
        {
            ConnectionString = connectionString;
            TableName = tableName;
        }

        public bool IdInDatabase(string id)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Select COUNT(1) from {TableName} where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public void AddToDatabase(CarWashStore carWashStore)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Insert into {TableName} " +
                            "VALUES {@id, @address, @numOfWorker, @profit}";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", carWashStore.Id);
                    cmd.Parameters.AddWithValue("@address", carWashStore.Address);
                    cmd.Parameters.AddWithValue("@numOfWorker", carWashStore.NumOfWorkers);
                    cmd.Parameters.AddWithValue("@profit", carWashStore.Profit);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void ViewDatabase()
        {
            Console.WriteLine($"{"CarWashID",-20} {"Address",-25} {"Number of Workers",-22} {"Rating",-10} {"Profit per week",-10}");

            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"Select * from {TableName}";
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
                            double rating = Convert.ToDouble(reader["Rating"]);
                            int profit = Convert.ToInt32(reader["Profit"]);
                            Console.WriteLine($"{id,-20} {address,-25} {numOfWorkers,-22} {rating,-10} ${profit,-10}");
                        }
                    }
                }
            }
        }

        public void UpdateToDatabase(CarWashStore carWashStore, string oldId)
        {
            using (SqlConnection cnn = new SqlConnection(ConnectionString))
            {
                string sql = $"UPDATE {TableName} SET Id = @id, " +
                                                    "Address = @address, " +
                                                    "NumofWorkers = @numOfWorker, " +
                                                    "Profit = @profit " +
                                                    "where Id = @oldId}";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@id", carWashStore.Id);
                    cmd.Parameters.AddWithValue("@address", carWashStore.Address);
                    cmd.Parameters.AddWithValue("@numOfWorker", carWashStore.NumOfWorkers);
                    cmd.Parameters.AddWithValue("@profit", carWashStore.Profit);
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
                string sql = $"Delete from {TableName} where Id = @Id";
                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

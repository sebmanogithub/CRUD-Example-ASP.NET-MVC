using CRUDMVCApp.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDMVCApp.Data
{
    internal class GadgetDAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BondGadgetDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //Perform all operation on the database ...
        public List<GadgetModel> FetchAll()
        {
            List<GadgetModel> returnList = new List<GadgetModel>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryText = "SELECT * FROM Gadgets";
                SqlCommand sqlCmd = new SqlCommand(queryText, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GadgetModel item = new GadgetModel();
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Description = reader.GetString(2);
                        item.AppearsIn = reader.GetString(3);
                        item.WithThisActor = reader.GetString(4);

                        returnList.Add(item);
                    }
                }
            }

            return returnList;
        }

        public GadgetModel FetchOne(int id)
        {
            GadgetModel item = new GadgetModel();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryText = $"SELECT * FROM Gadgets WHERE Id = {id}";
                SqlCommand sqlCmd = new SqlCommand(queryText, sqlConnection);

                sqlConnection.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        item.Id = reader.GetInt32(0);
                        item.Name = reader.GetString(1);
                        item.Description = reader.GetString(2);
                        item.AppearsIn = reader.GetString(3);
                        item.WithThisActor = reader.GetString(4);

                    }
                }
            }

            return item;
        }

        public int Create(GadgetModel gadgetModel)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                string queryText = "INSERT INTO Gadgets (Name, Description, AppearsIn, WithThisActor) " +
                                   "VALUES (@Name, @Description, @AppearsIn, @WithThisActor); ";

                SqlCommand sqlCmd = new SqlCommand(queryText, sqlConnection);

                sqlCmd.Parameters.AddWithValue("@Name", gadgetModel.Name);
                sqlCmd.Parameters.AddWithValue("@Description", gadgetModel.Description);
                sqlCmd.Parameters.AddWithValue("@AppearsIn", gadgetModel.AppearsIn);
                sqlCmd.Parameters.AddWithValue("@WithThisActor", gadgetModel.WithThisActor);

                sqlConnection.Open();
                int newID = sqlCmd.ExecuteNonQuery();
                return newID;
            }
        }
    }
}
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InsertDataToDatabase
{
    public class MockData : IMockData
    {
        public string GetMockDataInsertionQuery(int numberOfJsonObjects, string tableName, string columname, string schemaName, string databaseName)
        {
            string insertQuery = $"INSERT INTO \"{databaseName}\".\"{schemaName}\".\"{tableName}\"({columname}) VALUES";
            Console.WriteLine("Creating insert query for 100 records.."); 
            for (int i = 0; i < numberOfJsonObjects; i++)
            {
                insertQuery += $"('{GetJSONObjectFromMockData(15000).Replace("'", " ")}')\n";
                if (i == numberOfJsonObjects-1)
                {
                    insertQuery += ";";
                }
                else
                {
                    insertQuery += ",";
                }
              
            }
            Console.WriteLine("Creating insert query for 100 records - COMPLETED");
            return insertQuery;
        }

        public string GetJSONObjectFromMockData(int numberOfObjectsToGet)
        {
            Random randomNames = new Random();
            Random randomRatings = new Random();
            Random randomPlaces = new Random();
            string jsonObject = "";
            Console.WriteLine($"Creating {numberOfObjectsToGet} json objects..");
            for (int i = 0; i < numberOfObjectsToGet; i++)
            {
                string name = NamesData.Names[randomNames.Next(0, NamesData.Names.Length)];
                double rating = Ratings.Rating[randomRatings.Next(0, Ratings.Rating.Length)];
                string complement = "";
                if (rating == 3.5)
                {
                    complement = "Good";
                }
                else if (rating == 3)
                {
                    complement = "Average";
                }
                else if (rating == 5)
                {
                    complement = "Excellent";
                }
                else if (rating > 3.5)
                {
                    complement = "Very Good";
                }
                else
                {
                    complement = "Bad";
                }
                jsonObject += $"{{\"place_name\":\"{ PlacesData.Places[randomPlaces.Next(0, PlacesData.Places.Length - 1)].Trim() }\",\"user_name\":\"{ name }\", \"ratings\":{ rating }, \"complement\":\"{ complement }\"}}";
                if (i < numberOfObjectsToGet - 1)
                {
                    jsonObject += ", ";
                }
            }
            Console.WriteLine("Creating JSON objects - COMPLETED");
            
            return jsonObject;
        }

        public int InsertMockData(int numberOfJsonObjects, string tableName, string columname, string databaseName, string connectionString, string schemaName = "public")
        {
            string insertQuery= GetMockDataInsertionQuery(numberOfJsonObjects, tableName, columname, schemaName, databaseName);
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            NpgsqlCommand command = new NpgsqlCommand(insertQuery, connection);
            connection.Open();
            Console.WriteLine("Inserting records to mock data");
            return command.ExecuteNonQuery();
           
        }

        
    }
}

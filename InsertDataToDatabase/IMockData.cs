using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertDataToDatabase
{
    public interface IMockData
    {
        /// <summary>
        /// Creates Insert query from Mock Data in order to run it in Postgres directly
        /// </summary>
        /// <param name="numberOfJsonObjects"></param>
        /// <param name="tableName"></param>
        /// <param name="columname"></param>
        /// <param name="schemaName"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        string GetMockDataInsertionQuery(int numberOfJsonObjects, string tableName, string columname, string schemaName, string databaseName);
        /// <summary>
        /// Creates JSON objects and will insert them in the table
        /// </summary>
        /// <param name="numberOfJsonObjects"></param>
        /// <param name="tableName"></param>
        /// <param name="columname"></param>
        /// <param name="databaseName"></param>
        /// <param name="connectionString"></param>
        /// <param name="schemaName"></param>
        /// <returns></returns>
        int InsertMockData(int numberOfJsonObjects, string tableName, string columname, string databaseName, string connectionString, string schemaName = "public");
        /// <summary>
        /// Creates JSON objects from MockData
        /// </summary>
        /// <param name="numberOfObjectsToGet"></param>
        /// <returns></returns>
        string GetJSONObjectFromMockData(int numberOfObjectsToGet);
    }
}

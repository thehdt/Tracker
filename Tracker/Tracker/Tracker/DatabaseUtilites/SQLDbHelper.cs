using System;
using System.Configuration;
using System.Data.SqlClient;
using Tracker.Enumerations;
using Tracker.Models;

namespace Tracker.DatabaseUtilites
{
    public static class SQLDbHelper
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

        public static DBStatus AddQuery(string query)
        {
            System.Diagnostics.Debug.WriteLine($"Inside AddQuery()");
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                command.CommandType = System.Data.CommandType.Text;
                int rowCount = command.ExecuteNonQuery();
                connection.Close();
                return rowCount > 0 ? DBStatus.Success : DBStatus.Failed;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.Failed;
            }
        }

        public static string CreateProjectQuery(Project project)
        {
            return $"INSERT INTO Projects(ID, Name) VALUES ('{project.ID}', '{project.Name}')";
        }

        public static DBStatus CreateDatabase()
        {
            System.Diagnostics.Debug.WriteLine($"Inside CreateDatabase()");
            try
            {
                return DBStatus.Success;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.Failed;
            }
        }

        public static DBStatus DoesDatabaseExist()
        {
            System.Diagnostics.Debug.WriteLine($"Inside DoesDatabaseExist()");
            try
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT db_id('TrakrDb')";
                var result = command.ExecuteScalar();

                return (result != DBNull.Value)? DBStatus.Found : DBStatus.NotFound;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.NotFound;
            }
        }

        private static DBStatus DoesTableExist(string tableName)
        {
            System.Diagnostics.Debug.WriteLine($"Inside DoesTableExist() - Checking Table: {tableName}");

            try
            {
                return DBStatus.Found;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.NotFound;
            }
        }
    }
}

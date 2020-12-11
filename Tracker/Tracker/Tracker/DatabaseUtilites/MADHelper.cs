using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Enumerations;

namespace Tracker.DatabaseUtilites
{
    public static class MADHelper
    {
        private static OleDbConnection connection = new OleDbConnection(ConfigurationManager.ConnectionStrings["MADbConnectionString"].ConnectionString);
        //public static DBStatus StoreBug(Bug bug)
        //{
        //    try
        //    {
        //        OleDbCommand cmd = connection.CreateCommand();
        //        connection.Open();
        //        cmd.CommandText = $"Insert into Bugs(ID,Title,Description,Severity,CreateDate,ModifiedDate)" +
        //            $"Values('{bug.ID}', '{bug.Title}', '{bug.Description}', '{bug.Severity}', '{bug.CreateDate}', '{bug.ModifiedDate}')";
        //        cmd.Connection = connection;
        //        cmd.ExecuteNonQuery();
        //        connection.Close();
        //        return DBStatus.Success;
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"{ex.Message}");
        //        connection.Close();
        //        return DBStatus.Failed;
        //    }
        //}
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.Enumerations;

namespace Tracker.DatabaseUtilites
{
    public static class SQLDbHelper
    {
        private static SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        public static DBStatus CreateDatabase()
        {
            try
            {
                return DBStatus.Success;
            }
            catch (Exception ex)
            {
                return DBStatus.Failed;
            }
        }
    }
}

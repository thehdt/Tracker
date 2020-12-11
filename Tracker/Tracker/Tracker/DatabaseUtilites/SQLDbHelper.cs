using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using Tracker.Enumerations;

namespace Tracker.DatabaseUtilites
{
    public static class SQLDbHelper
    {
        public static DBStatus AddProject(Project project)
        {
            System.Diagnostics.Debug.WriteLine($"Inside AddProject()");
            try
            {
                using (TrakrDbEntities context = new TrakrDbEntities())
                {
                    context.Projects.Add(project);
                    int stateEntries = context.SaveChanges();
                    return stateEntries > 0 ? DBStatus.Success : DBStatus.Failed;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.Failed;
            }
        }

        public static List<Project> GetProjects()
        {
            System.Diagnostics.Debug.WriteLine($"Inside GetProjects()");
            try
            {
                using (TrakrDbEntities context = new TrakrDbEntities())
                {
                    var projects = (from project in context.Projects select project);
                    return new List<Project>(projects);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Project>();
            }
        }
    }
}

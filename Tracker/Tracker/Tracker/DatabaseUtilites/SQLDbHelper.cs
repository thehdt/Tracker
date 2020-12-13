using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Enumerations;

namespace Tracker.DatabaseUtilites
{
    public static class SQLDbHelper
    {
        public async static Task<DBStatus> AddProject(Project project)
        {
            System.Diagnostics.Debug.WriteLine($"Inside AddProject()");
            try
            {
                using (TrakrDbEntities context = new TrakrDbEntities())
                {
                    context.Projects.Add(project);
                    int stateEntries = await context.SaveChangesAsync();
                    return stateEntries > 0 ? DBStatus.Success : DBStatus.Failed;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.Failed;
            }
        }

        public async static Task<List<Project>> GetProjects()
        {
            System.Diagnostics.Debug.WriteLine($"Inside GetProjects()");
            try
            {
                using (TrakrDbEntities context = new TrakrDbEntities())
                {
                    return await (from project in context.Projects select project).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return new List<Project>();
            }
        }

        public async static Task<DBStatus> DeleteProject(Project project)
        {
            System.Diagnostics.Debug.WriteLine($"Inside DeleteProjecT()");

            try
            {
                using (TrakrDbEntities context = new TrakrDbEntities())
                {
                    context.Entry(project).State = EntityState.Deleted;
                    int rows = await context.SaveChangesAsync();
                    return (rows == 1) ? DBStatus.Success : DBStatus.Failed;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return DBStatus.Failed;
            }
        }
    }
}

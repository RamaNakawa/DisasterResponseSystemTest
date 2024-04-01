using Microsoft.EntityFrameworkCore;

namespace DisasterResponseSystem.Models
{
    public static class MigrateDB
    {
        public static void MigrateDb(DataBaseConext dbContext)
        {
            try
            {
                dbContext.Database.Migrate();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

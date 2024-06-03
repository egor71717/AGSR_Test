using Db.Models;
using Microsoft.EntityFrameworkCore;

namespace Db
{
    public class AGSR_Context: DbContext
    {
        
        protected readonly String _connection;

        public AGSR_Context(String connection)
        {
            _connection = connection;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(_connection);
        }

        public DbSet<Patient> Patients { get; set; }
    }
}

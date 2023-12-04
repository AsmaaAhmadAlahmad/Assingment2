using Assingment2_Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading.Channels;

namespace Assingment2_Data
{
    public class Assingment2Context : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assingment2DB;");
                //.LogTo(Log => Console.WriteLine(Log),
                //new[] {DbLoggerCategory.Database.Command.Name },
                //Microsoft.Extensions.Logging.LogLevel.Information
                //); 
        }

    }
}
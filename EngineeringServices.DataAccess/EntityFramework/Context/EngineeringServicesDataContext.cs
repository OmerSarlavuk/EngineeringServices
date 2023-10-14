using EngineeringServices.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EngineeringServices.DataAccess.EntityFramework.Context
{
    public class EngineeringServicesDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            string ConnectionString = configuration.GetConnectionString("ConnStr");
            optionsBuilder.UseSqlServer(ConnectionString);
        }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Engineering>? Engineerings { get; set; }
        public DbSet<Message>? Messages { get; set; }   
        public DbSet<Note>? Notes { get; set; }
        public DbSet<Person>? Persons { get; set; }
        public DbSet<PersonalInformation>? PersonalInformations { get; set; }
        public DbSet<WorkInformation>? WorkInformations { get; set; }
    }
}

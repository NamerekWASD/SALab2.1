using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Models;
using Microsoft.Extensions.Configuration;

namespace DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string ConnectionString;
        public ApplicationDbContext()
            :base()
        {
        }
        public ApplicationDbContext(string connectionString)
            : base()
        {
            ConnectionString = connectionString;
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<RequestedPlace> RequestedPlaces { get; set; }
        public DbSet<RequestStoreModel> Requests { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string constring = null;
            if (ConnectionString == null)
            {
                var builder = new ConfigurationBuilder();

                builder.SetBasePath(Directory.GetCurrentDirectory());

                builder.AddJsonFile("appsettings.json");

                var config = builder.Build();

                constring = config.GetConnectionString("DefaultConnection");
            }
            else
            {
                constring = ConnectionString;
            }

            optionsBuilder
                .UseSqlServer(constring)
                .UseLazyLoadingProxies();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private string ConnectionString { get; set; }
        public ApplicationDbContext()
            :base()
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
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
            optionsBuilder
                .UseLazyLoadingProxies();
            if (ConnectionString != null && ConnectionString.Length > 0)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            else
            { 
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PCOdb;Trusted_Connection=True;");
            }
        }
    }
}

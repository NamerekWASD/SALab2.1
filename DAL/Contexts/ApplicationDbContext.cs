using Microsoft.EntityFrameworkCore;
using Models;

namespace DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<RequestedPlace> RequestedPlaces { get; set; }
        public DbSet<RequestStoreModel> Requests { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=PCOdb;Trusted_Connection=True;");
        }
    }
}

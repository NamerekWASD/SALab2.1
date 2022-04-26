
using Microsoft.EntityFrameworkCore;
using Models.CommentModels;
using Models.MediaModels;
using Models.PlaceModels;
using Models.UserModels;

namespace DAL.Context
{
    public class PlaceContext : DbContext
    {
        public PlaceContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FileContainerModel> Files { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
    }
}

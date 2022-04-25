using DAL.Models.CommentEntity;
using DAL.Models.MediaEntity.MatchingToPlace;
using DAL.Models.PersonEntity;
using DAL.Models.PlaceEntity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class PlaceContext : DbContext
    {
        public PlaceContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FileContainer> Files { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Models;

namespace DAL.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            :base()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<RequestedPlace> RequestedPlaces { get; set; }
        public DbSet<RequestStoreModel> Requests { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies()
                .UseSqlServer("name=ConnectionStrings:DefaultConnection");
        }
    }
}

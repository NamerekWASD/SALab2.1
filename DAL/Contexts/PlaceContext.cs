
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
            /*Database.EnsureDeleted();*/
            Database.EnsureCreated();
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        public DbSet<FileContainerModel> Files { get; set; }
        public DbSet<LoginModel> LoginData { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlaceModel>()
                .HasMany(c => c.Comments)
                .WithOne(p => p.PlaceWhereLeft)
                .HasForeignKey(p => p.PlaceWhereLeftId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlaceModel>()
                .HasMany(m => m.Media)
                .WithOne(p => p.PlaceWhereAttached)
                .HasForeignKey(p => p.PlaceWhereAttachedId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserModel>()
                .HasMany(l => l.LeftComments)
                .WithOne(u => u.UserWhoLeft)
                .HasForeignKey(u => u.UserWhoLeftId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
                .HasMany(f => f.FilesAttached)
                .WithOne(u => u.UserWhoAttached)
                .HasForeignKey(u => u.UserWhoAttachedId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserModel>()
                .HasMany(p => p.VisitedPlaces)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder
                .Entity<LoginModel>()
                .HasOne(d => d.User).WithOne(u => u.AuthentificationData)
                .HasForeignKey<UserModel>(u => u.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Research.Dotnet5AndOdata.Entities;

namespace Research.Dotnet5AndOdata.Db
{
    //dotnet tool update --global dotnet-ef
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStore> BooksStores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.FirstName).HasMaxLength(50);
                b.Property(p => p.LastName).HasMaxLength(50);

                b.HasMany(p=>p.Stores).WithOne(p => p.Owner).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(p=>p.Books).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Store>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<BookStore>(b =>
            {
                b.HasKey(p => new {p.BookId, p.StoreId});

                b.HasOne(pt => pt.Book)
                    .WithMany(p => p.BookStore)
                    .HasForeignKey(pt => pt.BookId);

                b.HasOne(pt => pt.Store)
                    .WithMany(t => t.BookStore)
                    .HasForeignKey(pt => pt.StoreId).OnDelete(DeleteBehavior.ClientNoAction);
            });
           
        }
    }
}
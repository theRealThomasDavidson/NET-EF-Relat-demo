using asp_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(a => a.AuthorId);
            base.OnModelCreating(modelBuilder);
        }
        
    }

}

using HomeworkPustok.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeworkPustok.DAL
{
    public class PustokDbContext:DbContext
    {
        public PustokDbContext(DbContextOptions<PustokDbContext>opt):base(opt)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public DbSet<BookImage> Bookİmages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BookTag> BookTag { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookTag>().HasKey(x =>new {x.TagId,x.BookId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

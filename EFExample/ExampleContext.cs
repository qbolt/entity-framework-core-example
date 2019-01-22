using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFExample
{
    public class ExampleContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("server=127.0.0.1;port=5432;database=example;userid=postgres;password=bondstone");
        }
    }

    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
    
    public class Book
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Title { get; set; }
        public Author Books { get; set; }
    }
}
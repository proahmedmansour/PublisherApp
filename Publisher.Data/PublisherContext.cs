using Microsoft.EntityFrameworkCore;
using Publisher.Domain;

namespace Publisher.Data
{
    // Provides EF Core's database connectivity and tracks changes to objects
    public class PublisherContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
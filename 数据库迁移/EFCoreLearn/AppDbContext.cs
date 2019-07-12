using Microsoft.EntityFrameworkCore;

namespace EFCoreLearn
{
    public class AppDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        private const string ConnectionString =            //#A
            @"Server=(localdb)\MSSQLLocalDB; Database=Text2; user id=sa; password=111111; MultipleActiveResultSets=True; App=EntityFramework;";
 
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString); //#B
        }

        
    }
}
       



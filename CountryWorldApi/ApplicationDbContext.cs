using Microsoft.EntityFrameworkCore;

namespace CountryWorldApi
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"
                User Id=postgres.byeytndngzpikktidggr;
                Password=Trints11.06;
                Server=aws-0-us-west-1.pooler.supabase.com;
                Port=5432;
                Database=postgres;
            ";
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}

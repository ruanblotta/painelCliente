using Microsoft.EntityFrameworkCore;

namespace ClienteModels
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<ApplicationBuilder> options) : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StreamingDienst.API.Models;

namespace StreamingDienst.API.Data

{   // Dient für das Entity Framework zu PostgreSql
    public class AppDbContext : DbContext
    {
        #region Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<User> Users => Set<User>();
        #endregion
    }
}

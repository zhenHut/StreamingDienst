using Microsoft.EntityFrameworkCore;
using StreamingDienst.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingDienst.API.Data

{
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

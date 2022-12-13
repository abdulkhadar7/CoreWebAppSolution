using CoreWebApp.DAL.DbSets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace CoreWebApp.DAL.Context
{
    public  class CoreDbContext : DbContext
    {
        public CoreDbContext(DbContextOptions<CoreDbContext> options) : base (options) //base("")
        {

        }

        public virtual Microsoft.EntityFrameworkCore.DbSet<Categories> Categories { get; set; }
    }
}

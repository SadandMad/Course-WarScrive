using Course.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Data
{
    public class AppDBContent: DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) :base(options) {

        }
        public DbSet<Unit> Unit { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<RosterItem> RosterItem { get; set; }
    }
}

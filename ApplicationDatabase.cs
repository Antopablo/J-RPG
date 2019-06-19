using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    class ApplicationDatabase : DbContext
    {
        //public DbSet<WorldMap> WorldMaps { get; set; }
        //public DbSet<Interest> Interests { get; set; }

        public DbSet<Coordinates> Coordinates { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}

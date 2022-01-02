using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPStudents_withoutDB
{
    public class ContextLocal : DbContext
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public ContextLocal()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite("Filename=DB.db");
            //optionsBuilder.UseSqlite("Filename=DB_1.db");
            optionsBuilder.UseSqlite("Filename=DB_2.db");
        }
    }
}

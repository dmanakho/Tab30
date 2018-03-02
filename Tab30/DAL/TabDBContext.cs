using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tab30.Models;

namespace Tab30.DAL
{
    public class TabDBContext : DbContext
    {
        public TabDBContext():base("TabDBContext")
        {
            
        }

        public DbSet<Tablet> Tablets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<PartOrder> PartOrders { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Tech> Teches { get; set; }
        public DbSet<ProblemArea> ProblemAreas { get; set; }
        public DbSet<RepairType> RepairTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Repair>()
                .HasMany<ProblemArea>(p => p.ProblemAreas)
                .WithMany(r => r.Repairs)
                .Map(rp => {
                    rp.MapLeftKey("RepairID");
                    rp.MapRightKey("ProblemAreaID");
                    rp.ToTable("RepairProblemAreas");
                });

        }

       
    }

    
}
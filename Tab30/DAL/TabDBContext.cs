using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Tab30.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.Infrastructure;

namespace Tab30.DAL
{
    public class TabDBContext : DbContext
    {
        public TabDBContext() : base("TabDBContext")
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
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Repair>()
                .HasMany(p => p.ProblemAreas)
                .WithMany(r => r.Repairs)
                .Map(rp =>
                {
                    rp.MapLeftKey("RepairID");
                    rp.MapRightKey("ProblemAreaID");
                    rp.ToTable("RepairProblemAreas");
                });


        }

        public override int SaveChanges()
        {
            //get user audit value if not supplied
            string auditUser = "Anonymous";

            try //need to try because HttpContext may not exist
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    auditUser = HttpContext.Current.User.Identity.Name;
            }
            catch (Exception)
            { }

            DateTime auditDate = DateTime.UtcNow;

            foreach (DbEntityEntry<IAuditable> entry in ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = auditDate;
                    entry.Entity.CreatedBy = auditUser;
                    entry.Entity.UpdatedOn = auditDate;
                    entry.Entity.UpdatedBy = auditUser;
                }
                else if (entry.State == EntityState.Modified)
                {
                    //if (!entry.Entity.CreatedOn.HasValue)
                    //{
                    //    entry.Entity.CreatedOn = auditDate;
                    //}
                    entry.Entity.UpdatedOn = auditDate;
                    entry.Entity.UpdatedBy = auditUser;
                }
            }
            return base.SaveChanges();
        }
    }


}
using Cloud_Connectiv_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Cloud_Connectiv_Task.Context
{
    public class TODOContext : DbContext
    {
        public DbSet<TODO> TODOS { get; set; }
        public DbSet<TODO_MIRROR> TODO_MIRRORS { get; set; }


        public int SaveChanges(int ID)
        {
            Audit(ID);
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync(int ID)
        {
            Audit(ID);
            return await base.SaveChangesAsync();
        }

        public void Audit(int ID)
        {
            var items = this.ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified)
                            && x.Entity != null
                            && x.Entity is Logging)
                .Select(x => x)
                .ToList();

            foreach (var item in items)
            {
                var auditable = (Logging)item.Entity;
                var createNew = (item.State == EntityState.Added);
                auditable.Audit(ID, createNew);
            }
        }

    }
}

 
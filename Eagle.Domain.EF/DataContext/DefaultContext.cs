using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Eagle.Domain.EF.Map;
using Eagle.Model;

namespace Eagle.Domain.EF.DataContext
{
    public class DefaultContext : DbContext
    {
        static DefaultContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Migrations.Configuration>());
            //Database.SetInitializer<DefaultContext>(null);

#if DEBUG
            DbInterception.Add(new EFIntercepterLogging());
#endif
        }
        public DefaultContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }
        public void ModifiedModel(object entity)
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(LetterMap)));

        }

        public DbSet<Letter> Letters { get; set; }

        /// <summary>
        /// 系统配置库
        /// </summary>
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}

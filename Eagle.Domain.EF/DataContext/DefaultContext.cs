using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Reflection;
using Eagle.Domain.EF.Map;
using Eagle.Model;
using Eagle.Zero.Infrastructrue.Utility;

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
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
            this.Configuration.UseDatabaseNullSemantics = false;
        }

        public void ModifiedModel(object entity)
        {
            this.Entry(entity).State = EntityState.Modified;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(LetterMap)));
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Letter> Letters
        {
            get; set;
        }

        /// <summary>
        /// 系统配置库
        /// </summary>
        public DbSet<Warehouse> Warehouses
        {
            get; set;
        }

        public DbSet<Electrocardiogram> Electrocardiograms
        {
            get; set;
        }

        public DbSet<Tree> Trees
        {
            get; set;
        }

    }
}

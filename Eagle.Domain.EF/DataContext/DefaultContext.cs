using System;
using System.Data.Entity;
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
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DefaultContext, Migrations.Configuration>());
            }
            catch (Exception ex)
            {
                LogUtility.SendError(ex);
                throw;
            }
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
            LogUtility.SendTrace("执行模型修改");
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

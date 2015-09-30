using System;
using System.Data.Entity;
using System.Reflection;
using Eagle.Domain.EF.CoreEntity;
using Eagle.Domain.EF.Map;
using Eagle.Model;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.EF.DataContext
{
    public class MonitorContext : DefaultContext
    {
        static MonitorContext()
        {
            Database.SetInitializer<MonitorContext>(null);

        }

        public DbSet<Electrocardiogram> Electrocardiograms
        {
            get; set;
        }

        public DbSet<Tree> Trees
        {
            get; set;
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //LogUtility.SendTrace("执行模型修改2");
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetAssembly(typeof(TreeMap)));
            //modelBuilder.Conventions.Add<UnmapCoreEntitiesConvention>();

            //base.OnModelCreating(modelBuilder);
        }
    }
}
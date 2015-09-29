using System.Data.Entity;
using Eagle.Model;

namespace Eagle.Domain.EF.DataContext
{
    public class MonitorContext : DefaultContext
    {
        public DbSet<Electrocardiogram> Electrocardiograms { get; set; }
    }
}
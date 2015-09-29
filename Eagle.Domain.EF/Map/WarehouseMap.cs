using System.Data.Entity.ModelConfiguration;
using Eagle.Model;

namespace Eagle.Domain.EF.Map
{
    public class WarehouseMap : EntityTypeConfiguration<Warehouse>
    {
        /// <summary>
        /// Initializes a new instance of EntityTypeConfiguration
        /// </summary>
        public WarehouseMap()
        {
            this.HasKey(x => x.ID);
            this.Property(x => x.Value).HasMaxLength(1000);
            this.Property(x => x.Description).HasMaxLength(1000);

        }
    }
}
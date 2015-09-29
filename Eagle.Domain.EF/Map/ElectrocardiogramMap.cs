using System.Data.Entity.ModelConfiguration;
using Eagle.Model;

namespace Eagle.Domain.EF.Map
{
    public class ElectrocardiogramMap : EntityTypeConfiguration<Electrocardiogram>
    {
        /// <summary>
        /// Initializes a new instance of EntityTypeConfiguration
        /// </summary>
        public ElectrocardiogramMap()
        {
            this.HasKey(x => x.ID);
        }
    }
}
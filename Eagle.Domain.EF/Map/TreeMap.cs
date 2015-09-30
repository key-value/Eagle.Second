using System.Data.Entity.ModelConfiguration;
using Eagle.Model;

namespace Eagle.Domain.EF.Map
{
    public class TreeMap : EntityTypeConfiguration<Tree>
    {
        /// <summary>
        /// Initializes a new instance of EntityTypeConfiguration
        /// </summary>
        public TreeMap()
        {
            this.HasKey(x => x.ID);
        }
    }
}
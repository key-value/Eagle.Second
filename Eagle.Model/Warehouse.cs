using System;
using Eagle.Infrastructrue;
using Eagle.Zero.Domain.Core.Model;

namespace Eagle.Model
{
    public class Warehouse : IAggregateRoot
    {
        public Guid ID
        {
            get; set;
        }

        public SystemType KeyName
        {
            get; set;
        }

        public string Value
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public DateTime LastUpdateTime
        {
            get; set;
        }
    }

    public enum SystemType
    {
        LastUpdateCpu = 1,
    }
}
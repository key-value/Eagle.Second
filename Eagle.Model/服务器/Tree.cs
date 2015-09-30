using System;
using Eagle.Zero.Domain.Core.Model;

namespace Eagle.Model
{
    public class Tree : IEntity
    {
        public Guid ID
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public DateTime CreateTime
        {
            get; set;
        }

        public string IpAddr
        {
            get; set;
        }

        public DateTime LastUpdateTime
        {
            get; set;
        }
    }
}
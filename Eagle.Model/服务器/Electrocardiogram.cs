using System;
using Eagle.Zero.Domain.Core.Model;

namespace Eagle.Model
{
    public class Electrocardiogram : IEntity
    {
        public Guid ID { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime ReceiveTime { get; set; }

        public double CpuNum { get; set; }

        public double Memory { get; set; }

        public Guid MachineId { get; set; }

        public string Description { get; set; }

        public double AllMemory { get; set; }
    }
}
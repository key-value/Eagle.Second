using System;
using System.Collections.Generic;
using Eagle.Infrastructrue;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.Events
{
    public class HeartbeatEvent : PostHttpEvent
    {
        public HeartbeatEvent(List<HeartbeatBody> heartbeatBodies, Guid machId)
        {
            Area = "Architecture";
            Action = "Collect";
            Controller = "Heartbeat";


            Param.Add("heartbeatBodys", heartbeatBodies.ToJson());
            Param.Add("machineId", machId.ToString());
            //HttpUrl = string.Format("http://{0}/Architecture/Heartbeat/Collect", SystemConst.PirateAddress);

        }
    }
}
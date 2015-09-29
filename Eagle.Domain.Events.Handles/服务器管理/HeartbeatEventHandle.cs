using System.Collections.Generic;
using System.Linq;
using Eagle.Infrastructrue;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.Events.Handles
{
    [Injection(typeof(IDomainEventHandler<HeartbeatEvent>))]
    public class HeartbeatEventHandle : IDomainEventHandler<HeartbeatEvent>
    {
        public void Handle(HeartbeatEvent evnt)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("heartbeatBodys", evnt.HeartbeatBodies.ToJson());
            dic.Add("machineId", evnt.MachId.ToString());

            var param = string.Join("&", dic.Select(x => string.Format("{0}={1}", x.Key, x.Value)));

            var resString = HttpWebResponseUtility.CreatePostHttpResponse(evnt.HttpUrl, param, 30000, contentType: "application/x-www-form-urlencoded");

            var result = resString.ToDeserialize<Cells>();
            if (result == null)
            {
                return;
            }
            if (!result.Flag)
            {
                LogUtility.SendError(result.Message);
            }


        }
    }
}
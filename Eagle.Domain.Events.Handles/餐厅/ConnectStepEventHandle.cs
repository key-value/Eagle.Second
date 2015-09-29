using System.Collections.Generic;
using System.Linq;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.Events.Handles
{
    [Injection(typeof(IDomainEventHandler<ConnectStepEvent>))]
    public class ConnectStepEventHandle : IDomainEventHandler<ConnectStepEvent>
    {
        public void Handle(ConnectStepEvent evnt)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("updateConnectStep", evnt.ConnectStep.ToJson());

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
using System.Linq;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.Events.Handles
{
    [Injection(typeof(IDomainEventHandler<IPostHttpEvent>))]
    public class PostHttpEventHandle : IDomainEventHandler<IPostHttpEvent>
    {
        public void Handle(IPostHttpEvent evnt)
        {
            var param = string.Join("&", evnt.GetParam().Select(x => string.Format("{0}={1}", x.Key, x.Value)));

            var httpUrl = evnt.GetHttpUrl();

            var resString = HttpWebResponseUtility.CreatePostHttpResponse(httpUrl, param, 30000, contentType: "application/x-www-form-urlencoded");

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
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Eagle.Infrastructrue;
using Eagle.Zero.Domain.Events.Event;

namespace Eagle.Domain.Events
{
    public abstract class PostHttpEvent : DomainEvent, IPostHttpEvent
    {
        public Dictionary<string, string> Param = new Dictionary<string, string>();

        public string Area;

        public string Action;

        public string Controller;

        public Dictionary<string, string> GetParam()
        {
            return Param;
        }

        public string GetHttpUrl()
        {
            return string.Format("http://{0}/{1}/{2}/{3}", SystemConst.PirateAddress, Area, Controller, Action);
        }
    }
}
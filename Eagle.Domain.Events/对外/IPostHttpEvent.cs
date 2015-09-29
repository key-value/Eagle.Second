using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Eagle.Zero.Domain.Events;
using Eagle.Zero.Domain.Events.Event;

namespace Eagle.Domain.Events
{
    public interface IPostHttpEvent : IDomainEvent
    {

        Dictionary<string, string> GetParam();


        string GetHttpUrl();
    }
}
using System.Collections.Generic;
using Eagle.Zero.Domain.Core.Model;
using Eagle.Zero.Domain.Events.Event;

namespace Eagle.Domain.Events
{
    public class MsmqEvent : DomainEvent
    {

        public MsmqEvent()
        {
        }

        public MsmqEvent(IEntity source, Dictionary<string, string> paramDictionary)
            : base(source)
        {
            if (paramDictionary == null)
            {
                ParamDictionary = new Dictionary<string, string>();
            }
            else
            {
                ParamDictionary = paramDictionary;
            }

        }

        public Dictionary<string, string> ParamDictionary { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "RefreshRest")]
    public class RefleshRestService : ApplicationServices, IReceiveServices
    {
        private string _restIdList;

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            Flag = true;
            if (paramDictionary.VerificationString("RestID", ref _restIdList))
            {
                return true;
            }
            return false;
        }

        public void Execution()
        {
            DomainEvent.Publish(new RefreshAllRestEvent(_restIdList));
        }
    }
}
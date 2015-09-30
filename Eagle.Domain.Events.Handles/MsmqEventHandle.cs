using System;
using System.Collections.Generic;
using System.ServiceModel;
using Eagle.Infrastructrue;
using Eagle.Server.Interface.Interface.Msmq;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Domain.Events.Handles
{
    [Injection(typeof(IDomainEventHandler<MsmqEvent>))]
    public class MsmqEventHandle : IDomainEventHandler<MsmqEvent>
    {
        public void Handle(MsmqEvent evnt)
        {
            var binding = new NetMsmqBinding();

            binding.Security.Mode = NetMsmqSecurityMode.None;

            var endpointAddress = new EndpointAddress(string.Format("net.msmq://{0}/private/Message", SystemConst.MsmqAddress));

            using (ChannelFactory<IMessageService> messageChannelFactory = new ChannelFactory<IMessageService>(binding, endpointAddress))
            {
                try
                {
                    IMessageService messageService = messageChannelFactory.CreateChannel();

                    messageService.Entrance(evnt.ParamDictionary);
                }
                catch (Exception exception)
                {
                    LogUtility.SendError(exception);
                }
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Messaging;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Eagle.Infrastructrue;
using Eagle.Server.Interface;
using Eagle.Server.Interface.Interface.Msmq;
using Eagle.Server.WcfServer;
using Eagle.ViewModel;
using Eagle.Zero.Infrastructrue.Aop.Attribute;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "CaptureMsmq")]
    public class CaptureMsmq : ApplicationServices, IReceiveServices
    {
        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            Async = true;
            return true;
        }

        internal static string QueryName = string.Empty;
        internal static ServiceHost MyServiceHost = null;

        public void Execution()
        {
            //string queueAddress = @"msmq.formatname:DIRECT=OS:.\private$\Message";
            string queueAddress = $@"net.msmq://{SystemConst.MsmqAddress}/private/Message";
            QueryName = @".\Private$\Message";
            if (!MessageQueue.Exists(QueryName))
            {
                MessageQueue.Create(QueryName, true);
            }
            NetMsmqBinding binding = new NetMsmqBinding();
            binding.ExactlyOnce = true;
            binding.Security.Transport.MsmqAuthenticationMode = MsmqAuthenticationMode.None;
            binding.Security.Mode = NetMsmqSecurityMode.None;
            //var uri = new Uri("net.msmq://Tornade/private/Message");
            MyServiceHost = new ServiceHost(typeof(MessageService));
            MyServiceHost.AddServiceEndpoint(typeof(IMessageService), binding, queueAddress);

            MyServiceHost.Open();
        }
    }
}
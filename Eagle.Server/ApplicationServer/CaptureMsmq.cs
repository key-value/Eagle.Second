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

        internal static string queryName = string.Empty;
        internal static ServiceHost myServiceHost = null;

        public void Execution()
        {
            //string queueAddress = @"msmq.formatname:DIRECT=OS:.\private$\Message";
            string queueAddress = string.Format(@"net.msmq://{0}/private/Message", SystemConst.MsmqAddress);
            queryName = @".\Private$\Message";
            if (!MessageQueue.Exists(queryName))
            {
                MessageQueue.Create(queryName, true);
            }
            NetMsmqBinding binding = new NetMsmqBinding();
            binding.ExactlyOnce = true;
            binding.Security.Transport.MsmqAuthenticationMode = MsmqAuthenticationMode.None;
            binding.Security.Mode = NetMsmqSecurityMode.None;
            //var uri = new Uri("net.msmq://Tornade/private/Message");
            myServiceHost = new ServiceHost(typeof(MessageService));
            myServiceHost.AddServiceEndpoint(typeof(IMessageService), binding, queueAddress);

            myServiceHost.Open();
        }
    }
}
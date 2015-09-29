using System.Collections.Generic;
using Eagle.Server.ApiServer;
using Eagle.Server.Interface.Interface.Msmq;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Core.Model;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server.WcfServer
{
    public class MessageService : IMessageService
    {
        public void GetTest(UpdateLetter updateLetter)
        {
            LogUtility.SendInfo(updateLetter.ToJson());
        }

        public void Entrance(Dictionary<string, string> param)
        {
            var visitor = new Visitor();
            visitor.Parser(param);
        }
    }
}
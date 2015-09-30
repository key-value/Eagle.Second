using System;
using System.Collections.Generic;
using Client;
using Eagle.Infrastructrue;
using Eagle.Server.Interface;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "RefleshRestState")]
    public class RefleshRestStateService : ApplicationServices, IReceiveServices
    {
        public static int CanNotConnectTime = 1;

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            return true;
        }

        public void Execution()
        {
            if (string.IsNullOrEmpty(SystemConst.AuspiciousIp) || SystemConst.AuspiciousPort == 0)
            {
                LogUtility.SendError("未初始监控吉利端口!!!");
                return;
            }

            var commandLineClient = new MonitorClient(SystemConst.AuspiciousIp, SystemConst.AuspiciousPort);

            commandLineClient.SendDataToProxy(Guid.NewGuid(), 20);
            if (commandLineClient.State == MonitorClientState.Error)
            {
                if (CanNotConnectTime % 5 == 1)
                {
                    SmsUtility.SendAuspiciousError($"中间端连接有异常{DateTime.Now}");
                }
                CanNotConnectTime++;
            }
        }
    }
}
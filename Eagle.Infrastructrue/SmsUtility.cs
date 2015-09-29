using System;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Infrastructrue
{
    public class SmsUtility
    {
        public static string SendAuspiciousError(string message)
        {
            string mailParam =
                string.Format(
                    "?ID={0}&SenderCode={1}&SenderIp={2}&SenderPort={3}&Target={4}&PlugModulID={5}&Context={6}",
                    Guid.NewGuid(), "monitor.chidaoni.com", "10.0.1.172", "8888", "13799429593",
                    ((int)1 * 100 + (int)1) * 1000 + (int)2, string.Format("{1}:发送时间为{0}", DateTime.Now, message));
            var url = string.Format("http://sms.chidaoni.com/Transport{0}", mailParam);
            return HttpWebResponseUtility.CreateGetHttpResponse(url, 3000, null, null);
        }
    }
}
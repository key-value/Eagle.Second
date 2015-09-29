using System.Collections.Generic;
using System.Linq;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Infrastructrue
{
    public static class SendUtility
    {
        public static void ConnectStep(object connectStep)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("updateConnectStep", connectStep.ToJson());

            var param = string.Join("&", dic.Select(x => string.Format("{0}={1}", x.Key, x.Value)));

            var resString = HttpWebResponseUtility.CreatePostHttpResponse("http://first.eagle.com/Brand/RestState/UpdateConnectStep", param, 30000, contentType: "application/x-www-form-urlencoded");
        }



        public static void RefreshRest(object restIdList)
        {
            var dic = new Dictionary<string, string>();
            dic.Add("restIdList", restIdList.ToJson());

            var param = string.Join("&", dic.Select(x => string.Format("{0}={1}", x.Key, x.Value)));

            var resString = HttpWebResponseUtility.CreatePostHttpResponse("http://first.eagle.com/Brand/Heartbeat/Collect", param, 30000, contentType: "application/x-www-form-urlencoded");
        }
    }
}
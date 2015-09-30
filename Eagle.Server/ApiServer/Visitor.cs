using System;
using System.Collections.Generic;
using Eagle.Infrastructrue;
using Eagle.Server.Interface;
using Eagle.Server.SystemServer;
using Eagle.ViewModel;
using Eagle.Zero.Infrastructrue.Aop.Locator;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server.ApiServer
{
    public class Visitor
    {
        static Visitor()
        {
            HourglassService hourglassService = new HourglassService();
            if (SystemConst.Server)
            {
                hourglassService.Server_Start();
            }
            else
            {
                hourglassService.Client_Start();
            }
        }

        public Cells Parser(Dictionary<string, string> dictionary)
        {
            LogUtility.SendInfo(dictionary.ToJson());
            var cells = new Cells(false, "", 0);
            var receiveTime = DateTime.Now;
            if (!dictionary.ContainsKey("ActionName"))
            {
                return cells;
            }
            string actionName = dictionary["ActionName"];
            dictionary.Remove("ActionName");
            //dictionary.Add("receiveTime", receiveTime.ToString());
            try
            {
                IReceiveServices acceptService = ServiceLocator.Instance.GetService<IReceiveServices>(actionName);
                if (acceptService.Null())
                {
                    return cells;
                }
                acceptService.ReceiveTime = receiveTime;
                if (!acceptService.Verification(dictionary))
                {
                    LogUtility.SendInfo("参数验证错误");
                    return cells;
                }
                if (acceptService.Async)
                {
                    var action = new Action(() =>
                    {
                        try
                        {
                            acceptService.Execution();
                        }
                        catch (Exception e)
                        {
                            LogUtility.SendError(e);
                        }
                    });
                    action.BeginInvoke(ar =>
                    {
                        var endAction = ar.AsyncState as Action;
                        if (endAction != null)
                        {
                            try
                            {
                                endAction.EndInvoke(ar);
                            }
                            catch (Exception ex)
                            {
                                LogUtility.SendError(ex);
                            }
                        }
                    }, action);
                    cells.Flag = true;
                    return cells;
                }
                else
                {
                    LogUtility.SendInfo("同步执行开始");
                    acceptService.Execution();
                    cells = acceptService.GetResult();
                    return cells;
                }
            }
            catch (Exception e)
            {
                LogUtility.SendError(e);
            }
            return cells;
        }
    }
}
using System;
using System.Collections.Generic;
using Eagle.Domain.EF.DataContext;
using Eagle.Server.ApiServer;
using Eagle.Zero.Infrastructrue.Aop.Locator;
using Eagle.Zero.Infrastructrue.Hourglass;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server.SystemServer
{
    public class HourglassService
    {
        public void Server_Start()
        {


            try
            {
                Dictionary<string, string> value = new Dictionary<string, string>();
                value.Add("ActionName", "CaptureMsmq");
                var visitor = new Visitor();
                visitor.Parser(value);
                //sandDispatch.Add(new Sand(, "启动wcf服务", 0, (1000 * 4)));
            }
            catch (Exception exception)
            {
                LogUtility.SendError(exception);
            }

            var sandDispatch = SandDispatch.StartTask();
            try
            {
                sandDispatch.Add(new Sand(ServerExamination, "自动检测", 0, (1000 * 60 * 60)));
            }
            catch (Exception exception)
            {
                LogUtility.SendError(exception);
            }
            try
            {
                sandDispatch.Add(new Sand(RefleshRestStateExamination, "自动检测", 0, (1000 * 30)));
            }
            catch (Exception exception)
            {
                LogUtility.SendError(exception);
            }
        }

        public void Client_Start()
        {
            var sandDispatch = SandDispatch.StartTask();
            try
            {
                sandDispatch.Add(new Sand(Examination, "自动检测", 0, (1000 * 5)));
            }
            catch (Exception exception)
            {
                LogUtility.SendError(exception);
            }
        }
        private void ServerExamination()
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            value.Add("ActionName", "SendHeartbeat");
            var visitor = new Visitor();
            visitor.Parser(value);
        }

        private void RefleshRestStateExamination()
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            value.Add("ActionName", "RefleshRestState");
            var visitor = new Visitor();
            visitor.Parser(value);
        }




        private void Examination()
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            value.Add("ActionName", "FeelPulse");
            var visitor = new Visitor();
            visitor.Parser(value);
        }
    }
}
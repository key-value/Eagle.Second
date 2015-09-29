using System;
using System.Collections.Generic;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "ConnectStep")]
    public class ConnectStepService : ApplicationServices, IReceiveServices
    {

        private Guid _restaurantId;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _createTime;

        /// <summary>
        /// 链接类型
        /// </summary>
        private int _connectType;

        /// <summary>
        /// 链接地址
        /// </summary>
        private string _ipAddress;

        /// <summary>
        ///  链接吉利端时间
        /// </summary>
        private DateTime _sockCreateTime;
        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            Async = true;
            if (paramDictionary.VerificationGuid("RestaurantId", ref _restaurantId)
                && paramDictionary.TryVerification("CreateTime", ref _createTime)
                && paramDictionary.TryVerification("SockCreateTime", ref _sockCreateTime)
                && paramDictionary.VerificationString("IpAddress", ref _ipAddress)
                && paramDictionary.VerificationInt("ConnectType", ref _connectType))
            {
                return false;
            }
            return true;
        }

        public void Execution()
        {
            var connectStep = new ConnectStep();
            connectStep.ID = Guid.NewGuid();
            connectStep.ConnectResult = 1;

            connectStep.ConnectType = _connectType;
            connectStep.SockCreateTime = _sockCreateTime;
            connectStep.SockSendTime = _createTime;
            connectStep.IpAddress = _ipAddress;
            connectStep.RestaurantId = _restaurantId;

            DomainEvent.Publish(new ConnectStepEvent(connectStep));

            Flag = true;
        }
    }
}
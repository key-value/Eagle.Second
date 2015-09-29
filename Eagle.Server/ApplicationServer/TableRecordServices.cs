using System;
using System.Collections.Generic;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "TableRecord")]
    public class TableRecordServices : ApplicationServices, IReceiveServices
    {

        private DateTime _createTime;

        private int _actionId;

        private string _actionName;

        private Guid _tempUid;

        private Guid _tableId;

        private string _resultStr;

        private string _errorMessage;

        private Guid _exOrderId;

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary.TryVerification("CreateTime", ref _createTime) &&
                paramDictionary.VerificationInt("ActionId", ref _actionId) &&
                paramDictionary.VerificationString("ActionName", ref _actionName) &&
                paramDictionary.VerificationGuid("TempUid", ref _tempUid) &&
                paramDictionary.VerificationGuid("TableId", ref _tableId) &&
                paramDictionary.VerificationString("ResultStr", ref _resultStr) &&
                paramDictionary.VerificationString("ErrorMessage", ref _errorMessage) &&
                paramDictionary.VerificationGuid("ExOrderId", ref _exOrderId))
            {
                return false;
            }
            Async = true;
            return true;
        }

        public void Execution()
        {
            var tableRecord = new TableRecord();
            tableRecord.ActionId = _actionId;
            tableRecord.ActionName = _actionName;
            tableRecord.TempUid = _tempUid;
            tableRecord.TableId = _tableId;
            tableRecord.ResultStr = _resultStr;
            tableRecord.ErrorMessage = _errorMessage;
            tableRecord.ExOrderId = _exOrderId;

            DomainEvent.Publish(new TableRecordEvent(tableRecord));
        }
    }
}
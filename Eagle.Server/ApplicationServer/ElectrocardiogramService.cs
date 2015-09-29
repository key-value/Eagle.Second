using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Eagle.Domain.EF.DataContext;
using Eagle.Model;
using Eagle.Server.Interface;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "ElectrocardiogramService")]
    public class ElectrocardiogramService : ApplicationServices, IReceiveServices
    {
        private double _cpuNum;

        private double _memory;

        private double _allMemory;

        private DateTime _createTime;

        private Guid _machineId;

        private string _description;

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary.VerificationDouble("cpu", ref _cpuNum) &&
                paramDictionary.TryVerification("CreateTime", ref _createTime) &&
                paramDictionary.VerificationGuid("MachineID", ref _machineId) &&
                paramDictionary.TryVerification("memory", ref _memory) &&
                paramDictionary.VerificationString("Description", ref _description) &&
                paramDictionary.TryVerification("allMemory", ref _allMemory))
            {
                Async = true;
                return true;
            }
            return false;
        }

        public void Execution()
        {
            var electro = new Electrocardiogram();
            electro.ID = Guid.NewGuid();
            electro.ReceiveTime = this.ReceiveTime;
            electro.CreateTime = _createTime;
            electro.MachineId = _machineId;
            electro.CpuNum = _cpuNum;
            electro.Memory = _memory;
            electro.AllMemory = _allMemory;
            electro.Description = _description;
            using (var monitorContext = new MonitorContext())
            {
                monitorContext.Electrocardiograms.Add(electro);
                monitorContext.SaveChanges();
            }

            Flag = true;
            return;
        }

    }
}
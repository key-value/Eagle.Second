using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net;
using System.Web;
using Eagle.Domain.EF.DataContext;
using Eagle.Domain.Events;
using Eagle.Infrastructrue;
using Eagle.Model;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "SendHeartbeat")]
    public class SendHeartbeatServices : ApplicationServices, IReceiveServices
    {
        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            return true;
        }

        public void Execution()
        {
            var nowTime = DateTime.Today.AddHours(DateTime.Now.Hour);
            using (var monitorContext = new DefaultContext())
            {
                //var warehouses = monitorContext.Warehouses.FirstOrDefault(x => x.KeyName == SystemType.LastUpdateCpu);
                //if (warehouses == null)
                //{
                //    warehouses = new Warehouse();
                //    warehouses.ID = Guid.NewGuid();
                //    warehouses.KeyName = SystemType.LastUpdateCpu;
                //    warehouses.Value = "1";
                //    warehouses.LastUpdateTime = SqlDateTime.MinValue.Value;
                //    monitorContext.Warehouses.Add(warehouses);
                //}
                //else
                //{
                //    lastUpdate = warehouses.LastUpdateTime;
                //    monitorContext.ModifiedModel(warehouses);
                //}
                //if (nowTime < lastUpdate)
                //{
                //    return;
                //}

                var trees = monitorContext.Trees.Where(x => x.LastUpdateTime < nowTime);
                if (!trees.Any())
                {
                    return;
                }
                foreach (var tree in trees)
                {
                    var heartbeatList = new List<HeartbeatBody>();
                    var electrocardiograms = monitorContext.Electrocardiograms.Where(x => x.CreateTime >= tree.LastUpdateTime && x.CreateTime < nowTime).ToList();
                    var machIds = electrocardiograms.Select(x => x.MachineId).Distinct().ToList();
                    foreach (var machId in machIds)
                    {
                        var electrocGroup = electrocardiograms.Where(x => x.MachineId == machId).GroupBy(x => new DateTime(x.CreateTime.Year, x.CreateTime.Month, x.CreateTime.Day, x.CreateTime.Hour, 0, 0)).OrderBy(x => x.Key);
                        var maxTime = tree.LastUpdateTime;
                        foreach (var eletro in electrocGroup)
                        {
                            var heartbeat = new HeartbeatBody();
                            heartbeat.LogTime = eletro.Key;
                            heartbeat.MaxNum = eletro.Max(x => x.CpuNum);
                            heartbeat.AvgNum = eletro.Average(x => x.CpuNum);
                            heartbeat.MaxMemory = eletro.Max(x => x.AllMemory - x.Memory);
                            heartbeat.AvgMemory = eletro.Average(x => x.AllMemory - x.Memory);
                            heartbeat.HourTime = eletro.Key.Hour;
                            heartbeatList.Add(heartbeat);
                            if (heartbeat.LogTime > maxTime)
                            {
                                maxTime = heartbeat.LogTime;
                            }
                        }

                        IPostHttpEvent postHttpEvent = new HeartbeatEvent(heartbeatList, machId);
                        DomainEvent.Publish(postHttpEvent);

                        tree.LastUpdateTime = maxTime;
                        monitorContext.ModifiedModel(tree);
                    }
                }

                Flag = true;
                monitorContext.SaveChanges();
            }
        }
    }
}
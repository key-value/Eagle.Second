using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using Eagle.Domain.Events;
using Eagle.Infrastructrue;
using Eagle.Server.Interface;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "FeelPulse")]
    public class FeelPulseServices : ApplicationServices, IReceiveServices
    {
        static PerformanceCounter pp = new PerformanceCounter();//性能计数器

        //private static string _processName = "w3wp";

        static FeelPulseServices()
        {
            pp.CategoryName = "processor information";//指定获取计算机进程信息  如果传Processor参数代表查询计算机CPU
            pp.CounterName = "% Processor Time";//占有率
            pp.InstanceName = "_Total";
            pp.MachineName = ".";
        }

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            Async = true;
            return true;
        }

        public void Execution()
        {
            GetMemoryRelease();
            Flag = true;
        }

        private void GetMemoryDebug()
        {
            PerformanceCounter pp = new PerformanceCounter();//性能计数器
            pp.CategoryName = "Processor";//指定获取计算机进程信息  如果传Processor参数代表查询计算机CPU
            pp.CounterName = "% Processor Time";//占有率
            pp.InstanceName = "_Total";
            pp.MachineName = ".";


            string info = string.Empty;
            while (true)//1秒钟读取一次CPU占有率。
            {
                int index = 1;
                Process[] p = Process.GetProcessesByName("w3wp");
                if (p.Length > 0)
                {
                    foreach (Process pr in p)
                    {
                        info = pr.ProcessName + index++ + "内存：" +
                               (Convert.ToInt64(pr.WorkingSet64.ToString()) / 1024); //得到进程内存
                        Console.WriteLine(info + "    CPU使用情况：" + Math.Round(pp.NextValue(), 2) + "%");
                    }
                }
                else
                {
                    Console.WriteLine("暂时没东西耶!");
                }
                Thread.Sleep(1000);
            }
        }

        public void GetMemoryRelease()
        {
            var nowTime = DateTime.Now;
            double cpuNum = 0.0;

            var memorysb = GetMemory().Trim(',');

            float availablebytes = 0;
            float sumbytes = 0;
            ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject mo in mos.GetInstances())
            {
                if (mo["FreePhysicalMemory"] != null)
                {
                    availablebytes = float.Parse(mo["FreePhysicalMemory"].ToString());
                }
                if (mo["TotalVisibleMemorySize"] != null)
                {
                    sumbytes = float.Parse(mo["TotalVisibleMemorySize"].ToString());
                }
            }

            var memory = (availablebytes / 1024 / 1024).ToString();//获得已用内存量
            string allMemory = (sumbytes / 1024 / 1024).ToString();//获得内存总量





            cpuNum += Math.Round(pp.NextValue(), 2);
            //Console.WriteLine("    CPU使用情况：" + Math.Round(pp.NextValue(), 2) + "%" + cpuNum);
            var msmqEvent = new MsmqEvent();
            msmqEvent.ParamDictionary = new Dictionary<string, string>();
            msmqEvent.ParamDictionary.Add("ActionName", "ElectrocardiogramService");
            msmqEvent.ParamDictionary.Add("cpu", cpuNum.ToString(CultureInfo.InvariantCulture));
            msmqEvent.ParamDictionary.Add("memory", memory);
            msmqEvent.ParamDictionary.Add("CreateTime", nowTime.ToString(SystemConst.TimeStyle));
            msmqEvent.ParamDictionary.Add("MachineID", SystemConst.MachineId);
            msmqEvent.ParamDictionary.Add("Description", memorysb);
            msmqEvent.ParamDictionary.Add("allMemory", allMemory);
            DomainEvent.Publish(msmqEvent);
        }


        private static string GetProcessUserName(int pID)
        {
            string text1 = null;

            SelectQuery query1 = new SelectQuery("Select * from Win32_Process WHERE processID=" + pID);
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(query1);

            try
            {
                foreach (ManagementObject disk in searcher1.Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;

                    inPar = disk.GetMethodParameters("GetOwner");

                    outPar = disk.InvokeMethod("GetOwner", inPar, null);

                    text1 = outPar["User"].ToString();
                    break;
                }
            }
            catch
            {
                text1 = "SYSTEM";
            }

            return text1;
        }


        private string GetMemory()
        {
            var systemProcess = SystemConst.ProcessList.ToList();
            var memorysb = new StringBuilder();
            var i = 1;
            foreach (var procesbody in systemProcess)
            {
                Process[] p = Process.GetProcessesByName(procesbody);

                if (p.Length > 0)
                {
                    foreach (Process pr in p)
                    {
                        Console.WriteLine(i++);
                        PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", pr.ProcessName);
                        //PerformanceCounter.CloseSharedResources();
                        memorysb.Append(",");
                        memorysb.Append(procesbody);
                        memorysb.Append(":");
                        memorysb.Append(GetProcessUserName(pr.Id));
                        memorysb.Append(":");
                        memorysb.Append((Convert.ToInt64(pr.WorkingSet64 / 1024)));


                        LogUtility.SendTrace(memorysb.ToString());
                        memorysb.Append(":");
                        memorysb.Append((Convert.ToInt64(pf1.NextValue() / 1024)));


                        //计算
                        using (PerformanceCounter curtime = new PerformanceCounter("Process", "% Processor Time", pr.ProcessName))
                        {
                            //PerformanceCounter.CloseSharedResources();
                            double value = curtime.NextValue() / Environment.ProcessorCount;
                            memorysb.Append(":");
                            memorysb.Append(value);
                        }


                    }
                }
                else
                {
                    Console.WriteLine("暂时没东西耶!");
                }
            }
            return memorysb.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using Eagle.ViewModel;

namespace Eagle.Server.Interface
{
    public interface IReceiveServices : IDisposable
    {
        bool Verification(Dictionary<string, string> paramDictionary);

        void Execution();

        bool Async { get; set; }

        int Code { get; }

        string Message { get; }

        bool Flag { get; }

        Cells GetResult();

        DateTime ReceiveTime {  set; }
    }
}
using System.Collections.Generic;
using System.ServiceModel;
using Eagle.ViewModel;

namespace Eagle.Server.Interface.Interface.Msmq
{
    [ServiceContract(Namespace = "http://First.eagle.com")]
    public interface IMessageService
    {
        [OperationContract(IsOneWay = true)]
        void GetTest(UpdateLetter updateLetter);

        [OperationContract(IsOneWay = true)]
        void Entrance(Dictionary<string, string> param);
    }
}
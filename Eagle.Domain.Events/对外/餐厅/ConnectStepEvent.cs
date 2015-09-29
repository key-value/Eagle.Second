using Eagle.Domain.Events;
using Eagle.Infrastructrue;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.ViewModel
{
    public class ConnectStepEvent : PostHttpEvent
    {
        public ConnectStepEvent(ConnectStep connectStep)
        {
            Area = "Brand";
            Controller = "Brand";
            Action = "UpdateConnectStep";

            Param.Add("updateConnectStep", connectStep.ToJson());
        }
    }
}
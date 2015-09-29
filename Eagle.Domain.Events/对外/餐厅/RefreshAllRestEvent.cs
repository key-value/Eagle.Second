using Eagle.Domain.Events;

namespace Eagle.ViewModel
{
    public class RefreshAllRestEvent : PostHttpEvent
    {
        public RefreshAllRestEvent(string restId)
        {
            Area = "Brand";
            Controller = "Brand";
            Action = "RefreshAllRest";

            Param.Add("restId", restId);
        }
    }
}
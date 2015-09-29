using Eagle.Domain.Events;
using Eagle.Infrastructrue;
using Eagle.Zero.Domain.Events.Event;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.ViewModel
{
    public class TableRecordEvent : PostHttpEvent
    {
        public TableRecordEvent(TableRecord tableRecord)
        {
            Area = "Brand";
            Controller = "Rest";
            Action = "TableRecord";

            Param.Add("TableRecord", tableRecord.ToJson());
        }
    }
}
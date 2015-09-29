using System;

namespace Eagle.ViewModel
{
    public class TableRecord
    {
        public DateTime CreateTime { get; set; }

        public int ActionId { get; set; }

        public string ActionName { get; set; }

        public Guid TempUid { get; set; }

        public Guid TableId { get; set; }

        public string ResultStr { get; set; }

        public string ErrorMessage { get; set; }

        public Guid ExOrderId { get; set; }
    }
}
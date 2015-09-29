using System;

namespace Eagle.Model
{
    public class Letter
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreateTime { get; set; }

        public string Reply { get; set; }

        public DateTime ReplyTime { get; set; }
    }
}
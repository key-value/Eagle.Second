using System;
using Eagle.Model;

namespace Eagle.ViewModel
{
    public class ShowLetter
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime CreateTime { get; set; }

        public string Reply { get; set; }

        public DateTime ReplyTime { get; set; }

        public static ShowLetter CreateShowLetter(Letter letter)
        {
            var showLetter = new ShowLetter();
            showLetter.ID = letter.ID;
            showLetter.Title = letter.Title;
            showLetter.Message = letter.Message;
            showLetter.CreateTime = letter.CreateTime;
            showLetter.Reply = letter.Reply;
            showLetter.ReplyTime = letter.ReplyTime;
            return showLetter;
        }
    }
}
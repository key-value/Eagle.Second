using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eagle.Model;

namespace Eagle.ViewModel
{
    public class UpdateLetter
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Message { get; set; }

        public Letter CreateLetter()
        {
            var letter = new Letter();
            letter.ID = ID;
            letter.CreateTime = DateTime.Now;
            letter.Title = Title;
            letter.Message = Message;
            return letter;
        }
    }
}

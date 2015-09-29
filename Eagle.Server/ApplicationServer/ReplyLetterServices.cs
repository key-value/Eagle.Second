using System;
using System.Collections.Generic;
using Eagle.Domain.EF.DataContext;
using Eagle.Infrastructrue;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "Reply")]
    public class ReplyLetterServices : ApplicationServices, IReceiveServices
    {
        private UpdateLetter updateLetter;

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary.Verification("letter", ref updateLetter))
            {
                return true;
            }
            return false;
        }

        public void Execution()
        {
            var letter = updateLetter.CreateLetter();
            letter.CreateTime = ReceiveTime;
            letter.ReplyTime = DateTime.Now;
            using (var content = new DefaultContext())
            {
                content.Letters.Add(letter);
                content.SaveChanges();
            }
            updateLetter.Message = String.Format("CreateTime:{0},ReplyTime:{1}", letter.CreateTime, letter.ReplyTime);


            var resString = HttpWebResponseUtility.CreatePostHttpResponse(string.Format("http://{0}/Message/Letter/Reply", SystemConst.PirateAddress), updateLetter.ToJson(), 30000);

            var result = resString.ToDeserialize<Cells>();
            if (!result.Flag)
            {
                Flag = false;
                Message = result.Message;
                return;
            }
            Flag = true;

        }

    }
}
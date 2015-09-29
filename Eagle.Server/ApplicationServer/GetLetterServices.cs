using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Eagle.Domain.EF.DataContext;
using Eagle.Server.Interface;
using Eagle.ViewModel;
using Eagle.Zero.Infrastructrue.Aop.Attribute;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Server
{
    [Injection(typeof(IReceiveServices), "GetLetter")]
    public class GetLetterServices : ApplicationServices, IReceiveServices
    {
        public DateTime BeginTime;
        public DateTime EndTime;

        private List<ShowLetter> showLetters = new List<ShowLetter>();

        public bool Verification(Dictionary<string, string> paramDictionary)
        {
            if (paramDictionary.TryVerification("BeginTime", ref BeginTime) && paramDictionary.TryVerification("EndTime", ref EndTime))
            {
                return true;
            }
            return false;
        }

        public void Execution()
        {
            using (var content = new DefaultContext())
            {
                var letterList = content.Letters.Where(x => x.CreateTime >= BeginTime && x.CreateTime < EndTime).AsNoTracking().ToList();
                foreach (var letter in letterList)
                {
                    showLetters.Add(ShowLetter.CreateShowLetter(letter));
                }
            }
            Flag = true;
        }

        public override Cells GetResult()
        {
            var cells = base.GetResult();
            cells.Body = showLetters.ToJson();
            return cells;
        }
    }
}
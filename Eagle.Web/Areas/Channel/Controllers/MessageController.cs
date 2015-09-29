using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using Eagle.Server.ApiServer;
using Eagle.ViewModel;
using Eagle.Zero.Infrastructrue.Utility;

namespace Eagle.Web.Areas.Channel.Controllers
{
    public class MessageController : ApiController
    {
        // GET: api/Message
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Message/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Message
        public Cells Post([FromBody]Dictionary<string, string> value)
        {
            LogUtility.SendFatal(value.ToJson());
            var visitor = new Visitor();
            return visitor.Parser(value);
        }

        // PUT: api/Message/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Message/5
        public void Delete(int id)
        {
        }
    }
}

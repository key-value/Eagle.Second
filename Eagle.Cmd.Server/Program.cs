using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eagle.Server.ApiServer;

namespace Eagle.Cmd.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            var visitor = new Visitor();
            //value.Add("ActionName", "");
            var result = visitor.Parser(value);
            Console.ReadLine();
        }
    }
}

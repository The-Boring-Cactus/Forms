using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace bpaforms.Server
{
    public class MSkel
    {
        public MSkel() { }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Comand { get; set; }

        public string? Data { get; set; }
        public string? Type { get; set; }
        public JObject? Respose { get; set; }
    }
}

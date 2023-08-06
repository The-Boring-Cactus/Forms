using Newtonsoft.Json.Linq;
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

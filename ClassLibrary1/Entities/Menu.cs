using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FileParser.Domain.Entities
{
    [JsonObject(Title = "menu")]
    public class Menu
    {
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }
        [JsonProperty(PropertyName = "items")]
        public IEnumerable<MenuItem> Items { get; set; }
    }
    public class MenuItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    }
}

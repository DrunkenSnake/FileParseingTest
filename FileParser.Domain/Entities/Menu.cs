using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FileParser.Domain.Entities
{
    public class Wrap
    {
        [JsonProperty(PropertyName = "menu")]
        public Menu Menu { get; set; }
    }
    public class Menu
    {
        [JsonProperty(PropertyName = "header")]
        public string Header { get; set; }
        [JsonProperty(PropertyName = "items")]
        public MenuItem[] Items { get; set; }
    }
    public class MenuItem
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate, PropertyName = "label")]
        public string Label { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Products.Domain.Models
{
    public class Product
    {
        public int id { get; set; }
        public string? name { get; set; }
        public decimal price { get; set; }
        public decimal cost { get; set; }
        public int stock { get; set; }
        [JsonIgnore]
        public int state_id { get; set; }
    }
}

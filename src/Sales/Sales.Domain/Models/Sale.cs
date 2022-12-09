using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sales.Domain.Models
{
    public class Sale
    {
        public int id { get; set; }
        public decimal total_amount { get; set; }
        public decimal sub_total_amount { get; set; }
        public decimal iva_amount { get; set; }
        public int sale_status_id { get; set; }


    }
}

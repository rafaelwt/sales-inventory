using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Sales.Domain.Models
{
    public class SaleDetails
    {
        public int id { get; set; }
        public int sales_id { get; set; }
        public int product_id { get; set; }
        public decimal price_per_unit { get; set; }
        public int quantity_sold { get; set; }
        public decimal iva_amount { get; set; }
    }


}

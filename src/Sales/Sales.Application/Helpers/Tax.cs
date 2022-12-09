using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Helpers
{
    public static class Tax
    {
        public static decimal CalculateTaxIva(decimal amount)
        {
            // TODO: SE DEBE OBTENER EL IVA DE UNA TABLA PARAMETRIZADA;
            decimal IVA = 13;
            var tax_amount = amount * (IVA / 100);
            return tax_amount;
        }

    }
}

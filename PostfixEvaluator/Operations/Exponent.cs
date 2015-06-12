using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostfixEvaluator.Operations
{
    class Exponent : IOperation
    {
        public decimal CalculateResultOfOperation(List<decimal> arguments)
        {
            return Convert.ToDecimal(Math.Pow( Convert.ToDouble(arguments[0]), Convert.ToDouble(arguments[1])));
        }
    }
}

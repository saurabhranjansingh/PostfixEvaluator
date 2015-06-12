using System;
using System.Collections.Generic;

namespace PostfixEvaluator
{
    interface IOperation
    {        
        decimal CalculateResultOfOperation(List<decimal> arguments);
    }
}

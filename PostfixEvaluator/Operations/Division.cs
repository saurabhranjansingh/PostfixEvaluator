﻿using System;
using System.Collections.Generic;

namespace PostfixEvaluator.Operations
{
    class Division : IOperation
    {
        public decimal CalculateResultOfOperation(List<decimal> arguments)
        {
            return arguments[0] / arguments[1];
        }
    }
}

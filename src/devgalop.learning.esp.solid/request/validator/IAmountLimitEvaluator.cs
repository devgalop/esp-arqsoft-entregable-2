using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.request.validator
{
    public interface IAmountLimitEvaluator
    {
        bool Evaluate(decimal amount);
    }
}
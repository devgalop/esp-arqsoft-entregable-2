using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.request.validator
{
    public interface IRuleByRequestEvaluator
    {
        IMinimunDocumentationEvaluator CreateMinimunDocumentationEvaluator(ERequestType requestType);
        IAmountLimitEvaluator CreateAmountLimitEvaluator(ERequestType requestType);
    }
}
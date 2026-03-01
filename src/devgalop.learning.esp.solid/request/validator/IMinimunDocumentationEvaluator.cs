using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devgalop.learning.esp.solid.document;

namespace devgalop.learning.esp.solid.request.validator
{
    public interface IMinimunDocumentationEvaluator
    {
        bool Evaluate(List<Document> documents);
    }
}
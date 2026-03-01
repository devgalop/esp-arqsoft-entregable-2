using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devgalop.learning.esp.solid.request.strategy
{
    public class SubmittedStrategy : IStateExecutorStrategy
    {
        public Request Execute(Request request)
        {
            Console.WriteLine("Executing SubmittedStrategy");
            // Implementa lógica para el estado Submitted
            request.AssignState(ERequestState.UNDER_REVIEW);
            return request;
        }
    }
}
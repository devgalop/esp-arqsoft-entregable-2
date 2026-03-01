using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace devgalop.learning.esp.solid.request.strategy
{
    public class DraftStrategy : IStateExecutorStrategy
    {
        public Request Execute(Request request)
        {
            Console.WriteLine("Executing DraftStrategy");
            // Implementa lógica para el estado Draft
            request.AssignState(ERequestState.SUBMITTED);
            return request;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.strategy
{
    /// <summary>
    /// Estrategia de ejecución para el estado SUBMITTED.
    /// </summary>
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

    public static class SubmittedStrategyExtensions
    {
        public static HostApplicationBuilder AddSubmittedStrategy(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStateExecutorStrategy, SubmittedStrategy>();
            return builder;
        }
    }
}
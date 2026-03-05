using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace devgalop.learning.esp.solid.request.strategy
{
    /// <summary>
    /// Estrategia de ejecución para el estado inicial DRAFT.
    /// </summary>
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

    public static class DraftStrategyExtensions
    {
        public static HostApplicationBuilder AddDraftStrategy(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStateExecutorStrategy, DraftStrategy>();
            return builder;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.strategy
{
    public static class StrategyCommonExtensions
    {
        /// <summary>
        /// Agrega todas las estrategias de ejecución necesarias para manejar los diferentes estados de un request.
        /// </summary>
        /// <param name="builder">El constructor de la aplicación host.</param>
        /// <returns>El constructor de la aplicación host con las estrategias agregadas.</returns>
        public static HostApplicationBuilder AddStrategyExecutor(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<StateExecutorContext>();
            builder.AddDraftStrategy()
                    .AddSubmittedStrategy()
                    .AddUnderReviewStrategy();
            
            return builder;
        }
    }
}
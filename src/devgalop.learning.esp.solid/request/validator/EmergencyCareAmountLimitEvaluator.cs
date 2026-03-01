using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class EmergencyCareAmountLimitEvaluator : IAmountLimitEvaluator
    {
        public bool Evaluate(decimal amount)
        {
            return amount >= 0 && amount <= 3500000;
        }
    }

    public static class EmergencyCareAmountLimitEvaluatorExtensions
    {
        public static HostApplicationBuilder AddEmergencyCareAmountLimitEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAmountLimitEvaluator, EmergencyCareAmountLimitEvaluator>();
            return builder;
        }
    }
}
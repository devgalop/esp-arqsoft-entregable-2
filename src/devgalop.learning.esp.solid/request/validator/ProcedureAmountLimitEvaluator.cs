using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class ProcedureAmountLimitEvaluator : IAmountLimitEvaluator
    {
        public bool Evaluate(decimal amount)
        {
            return amount >= 0 && amount <= 2500000;
        }
    }

    public static class ProcedureAmountLimitEvaluatorExtensions
    {
        public static HostApplicationBuilder AddProcedureAmountLimitEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAmountLimitEvaluator, ProcedureAmountLimitEvaluator>();
            return builder;
        }
    }
}
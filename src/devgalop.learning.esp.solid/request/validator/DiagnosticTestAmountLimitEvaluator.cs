using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class DiagnosticTestAmountLimitEvaluator : IAmountLimitEvaluator
    {
        public bool Evaluate(decimal amount)
        {
            return amount >= 0 && amount <= 1200000;
        }
    }

    public static class DiagnosticTestAmountLimitEvaluatorExtensions
    {
        public static HostApplicationBuilder AddDiagnosticTestAmountLimitEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAmountLimitEvaluator, DiagnosticTestAmountLimitEvaluator>();
            return builder;
        }
    }
}
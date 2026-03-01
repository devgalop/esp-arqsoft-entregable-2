using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class AmountLimitRuleValidator(
        IRuleByRequestEvaluator evaluatorFactory
    ) : IRuleValidator
    {
        public bool Validate(Request request)
        {
            var evaluator = evaluatorFactory.CreateAmountLimitEvaluator(request.RequestType);
            return evaluator.Evaluate(request.Value);
        }
    }

    public static class AmountLimitRuleValidatorExtensions
    {
        public static HostApplicationBuilder AddAmountLimitRuleValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRuleValidator, AmountLimitRuleValidator>();
            return builder;
        }
    }
}
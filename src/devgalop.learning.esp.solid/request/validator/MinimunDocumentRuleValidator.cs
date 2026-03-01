using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class MinimunDocumentRuleValidator(
        IRuleByRequestEvaluator evaluatorFactory
    ) : IRuleValidator
    {
        public bool Validate(Request request)
        {
            var evaluator = evaluatorFactory.CreateMinimunDocumentationEvaluator(request.RequestType);
            return evaluator.Evaluate(request.Attachments);       
        }
    }

    public static class MinimunDocumentRuleValidatorExtensions
    {
        public static HostApplicationBuilder AddMinimunDocumentRuleValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRuleValidator, MinimunDocumentRuleValidator>();
            return builder;
        }
    }
}
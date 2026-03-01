using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class ProviderRuleValidator : IRuleValidator
    {
        private readonly List<string> validProviders =
        [
            "ProviderA",
            "ProviderB",
            "ProviderC"
        ];
        
        public bool Validate(Request request)
        {
            return request != null 
                && request.Provider != null
                && validProviders.Contains(request.Provider.Name);
        }
    }

    public static class ProviderRuleValidatorExtensions
    {
        public static HostApplicationBuilder AddProviderRuleValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRuleValidator, ProviderRuleValidator>();
            return builder;
        }
    }
}
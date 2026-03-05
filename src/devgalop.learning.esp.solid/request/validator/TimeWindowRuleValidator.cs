using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class TimeWindowRuleValidator : IRuleValidator
    {
        public bool Validate(Request request)
        {
            return request.CreatedAt >= DateTime.UtcNow.AddDays(-60) 
                && request.CreatedAt <= DateTime.UtcNow;
        }
    }

    public static class TimeWindowRuleValidatorExtensions
    {
        public static HostApplicationBuilder AddTimeWindowRuleValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRuleValidator, TimeWindowRuleValidator>();
            return builder;
        }
    }
}
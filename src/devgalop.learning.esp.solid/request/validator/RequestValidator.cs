using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class RequestValidator : IRuleValidator
    {
        public bool Validate(Request request)
        {
            return request != null
                && request.Value > 0
                && request.Attachments != null
                && request.Attachments.Count > 0
                && request.Patient != null
                && request.Provider != null
                && request.CreatedAt != default;
        }
    }

    public static class RequestValidatorExtensions
    {
        public static HostApplicationBuilder AddRequestValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IRuleValidator, RequestValidator>();
            return builder;
        }
    }
}
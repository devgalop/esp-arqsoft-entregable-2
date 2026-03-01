using devgalop.learning.esp.solid.request;
using devgalop.learning.esp.solid.request.builder;
using devgalop.learning.esp.solid.request.validator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request
{
    public static class RequestCommonExtensions
    {
        public static HostApplicationBuilder AddRequestServices(this HostApplicationBuilder builder)
        {
            builder.AddRequestValidators();
            builder.Services.AddScoped<IRequestBuilder, RequestBuilder>();
            return builder;
        }
    }
}
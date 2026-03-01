using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public static class ValidatorCommonExtensions
    {
        public static HostApplicationBuilder AddRequestValidators(this HostApplicationBuilder builder)
        {
            builder.AddEvaluators()
                    .AddMinimunDocumentRuleValidator()
                    .AddAmountLimitRuleValidator()
                    .AddProviderRuleValidator()
                    .AddTimeWindowRuleValidator()
                    .AddRequestValidator();
            return builder;
        }
    }
}
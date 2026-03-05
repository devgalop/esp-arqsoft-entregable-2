using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public static class ValidatorCommonExtensions
    {
        /// <summary>
        /// Agrega todos los validadores necesarios para evaluar un request.
        /// </summary>
        /// <param name="builder">El constructor de la aplicación host.</param>
        /// <returns>El constructor de la aplicación host con los validadores agregados.</returns>
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
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class MedicationAmountLimitEvaluator : IAmountLimitEvaluator
    {
        public bool Evaluate(decimal amount)
        {
            return amount >= 0 && amount <= 800000;
        }
    }

    public static class MedicationAmountLimitEvaluatorExtensions
    {
        public static HostApplicationBuilder AddMedicationAmountLimitEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAmountLimitEvaluator, MedicationAmountLimitEvaluator>();
            return builder;
        }
    }
}
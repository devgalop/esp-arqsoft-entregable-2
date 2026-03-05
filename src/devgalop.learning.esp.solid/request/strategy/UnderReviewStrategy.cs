using System.Text;
using devgalop.learning.esp.solid.request.validator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.strategy
{
    /// <summary>
    /// Estrategia de ejecución para el estado UNDER_REVIEW.
    /// </summary>
    /// <param name="validators">Los validadores de reglas que se utilizarán para evaluar el request.</param>
    public class UnderReviewStrategy(
        IEnumerable<IRuleValidator> validators
    ) : IStateExecutorStrategy
    {
        public Request Execute(Request request)
        {
            Console.WriteLine("Ejecutando estrategia de revisión de solicitud...");
            StringBuilder logbuilder = new();
            var invalidValidators = validators.Where(rule => !rule.Validate(request)).ToList();
            invalidValidators.ForEach(rule =>
            {
                logbuilder.AppendLine($"La solicitud no cumple con la regla: {rule.GetType().Name}");
            });
            if(invalidValidators.Count != 0)
            {
                Console.WriteLine(logbuilder.ToString());
                request.AssignState(ERequestState.REJECTED);
                request.AssignResult(new RequestResult(request.State, logbuilder.ToString()));
                return request;
            }
            request.AssignState(ERequestState.APPROVED);
            request.AssignResult(new RequestResult(request.State, "La solicitud cumple con los requisitos para ser aprobada"));
            return request;
        }
    }

    public static class UnderReviewStrategyExtensions
    {
        public static HostApplicationBuilder AddUnderReviewStrategy(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStateExecutorStrategy, UnderReviewStrategy>();
            return builder;
        }
    }
}
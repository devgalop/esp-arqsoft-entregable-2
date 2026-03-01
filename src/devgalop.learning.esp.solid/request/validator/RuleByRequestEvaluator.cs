
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class RuleByRequestEvaluator : IRuleByRequestEvaluator
    {
        public IAmountLimitEvaluator CreateAmountLimitEvaluator(ERequestType requestType)
        {
            return requestType switch
            {
                ERequestType.MEDICATION => new MedicationAmountLimitEvaluator(),
                ERequestType.PROCEDURE => new ProcedureAmountLimitEvaluator(),
                ERequestType.DIAGNOSTIC_TEST => new DiagnosticTestAmountLimitEvaluator(),
                ERequestType.EMERGENCY_CARE => new EmergencyCareAmountLimitEvaluator(),
                _ => throw new NotImplementedException()
            };
        }

        public IMinimunDocumentationEvaluator CreateMinimunDocumentationEvaluator(ERequestType requestType)
        {
            return requestType switch
            {
                ERequestType.MEDICATION => new MedicationMinimunDocumentEvaluator(),
                ERequestType.PROCEDURE => new ProcedureMinimunDocumentEvaluator(),
                ERequestType.DIAGNOSTIC_TEST => new DiagnosticTestMinimunDocumentValidator(),
                ERequestType.EMERGENCY_CARE => new EmergencyCareMinimunDocumentEvaluator(),
                _ => throw new NotImplementedException()
            };
        }
    }

    public static class RuleByRequestEvaluatorExtensions
    {
        public static HostApplicationBuilder AddEvaluators(this HostApplicationBuilder builder)
        {
             //Agrega los validadores de documentos mínimos
            builder.AddProcedureMinimunDocumentEvaluator()
                   .AddDiagnosticTestMinimunDocumentValidator()
                   .AddEmergencyCareMinimunDocumentEvaluator()
                   .AddMedicationMinimunDocumentEvaluator();

            //Agrega los validadores de límites de monto
            builder.AddMedicationAmountLimitEvaluator()
                   .AddProcedureAmountLimitEvaluator()
                   .AddDiagnosticTestAmountLimitEvaluator()
                   .AddEmergencyCareAmountLimitEvaluator();
            
            builder.Services.AddScoped<IRuleByRequestEvaluator, RuleByRequestEvaluator>();
            return builder;
        }
    }
}
using devgalop.learning.esp.solid.document;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class ProcedureMinimunDocumentEvaluator : IMinimunDocumentationEvaluator
    {
        public bool Evaluate(List<Document> documents)
        {
            return documents != null 
                && documents.Any(d => d.DocumentType == EDocumentType.MEDICAL_ORDER)
                && documents.Any(d => d.DocumentType == EDocumentType.INVOICE);
        }
    }

    public static class ProcedureMinimunDocumentEvaluatorExtensions
    {
        public static HostApplicationBuilder AddProcedureMinimunDocumentEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMinimunDocumentationEvaluator, ProcedureMinimunDocumentEvaluator>();
            return builder;
        }
    }
}
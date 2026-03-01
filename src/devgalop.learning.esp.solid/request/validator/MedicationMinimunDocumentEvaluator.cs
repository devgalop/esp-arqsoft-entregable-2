using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devgalop.learning.esp.solid.document;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class MedicationMinimunDocumentEvaluator : IMinimunDocumentationEvaluator
    {
        public bool Evaluate(List<Document> documents)
        {
            return documents != null
                && documents.Any(d => d.DocumentType == EDocumentType.PRESCRIPTION)
                && documents.Any(d => d.DocumentType == EDocumentType.INVOICE);
        }
    }

    public static class MedicationMinimunDocumentEvaluatorExtensions
    {
        public static HostApplicationBuilder AddMedicationMinimunDocumentEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMinimunDocumentationEvaluator, MedicationMinimunDocumentEvaluator>();
            return builder;
        }
    }
}
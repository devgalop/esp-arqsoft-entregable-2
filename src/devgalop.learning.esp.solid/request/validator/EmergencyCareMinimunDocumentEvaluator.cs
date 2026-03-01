using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devgalop.learning.esp.solid.document;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class EmergencyCareMinimunDocumentEvaluator : IMinimunDocumentationEvaluator
    {
        public bool Evaluate(List<Document> documents)
        {
            return documents != null
                && documents.Any(d => d.DocumentType == EDocumentType.MEDICAL_RECORD)
                && documents.Any(d => d.DocumentType == EDocumentType.INVOICE);
        }
    }

    public static class EmergencyCareMinimunDocumentEvaluatorExtensions
    {
        public static HostApplicationBuilder AddEmergencyCareMinimunDocumentEvaluator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMinimunDocumentationEvaluator, EmergencyCareMinimunDocumentEvaluator>();
            return builder;
        }
    }
}
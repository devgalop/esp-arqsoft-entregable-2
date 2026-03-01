using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devgalop.learning.esp.solid.document;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace devgalop.learning.esp.solid.request.validator
{
    public class DiagnosticTestMinimunDocumentValidator : IMinimunDocumentationEvaluator
    {
        public bool Evaluate(List<Document> documents)
        {
            return documents != null
                && documents.Any(d => d.DocumentType == EDocumentType.DIAGNOSTIC_RESULT)
                && documents.Any(d => d.DocumentType == EDocumentType.INVOICE)
                && documents.Any(d => d.DocumentType == EDocumentType.MEDICAL_ORDER);
        }
    }

    public static class DiagnosticTestMinimunDocumentValidatorExtensions
    {
        public static HostApplicationBuilder AddDiagnosticTestMinimunDocumentValidator(this HostApplicationBuilder builder)
        {
            builder.Services.AddScoped<IMinimunDocumentationEvaluator, DiagnosticTestMinimunDocumentValidator>();
            return builder;
        }
    }
}
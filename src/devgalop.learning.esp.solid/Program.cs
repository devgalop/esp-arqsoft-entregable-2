
using devgalop.learning.esp.solid.document;
using devgalop.learning.esp.solid.patient;
using devgalop.learning.esp.solid.provider;
using devgalop.learning.esp.solid.request;
using devgalop.learning.esp.solid.request.builder;
using devgalop.learning.esp.solid.request.facade;
using devgalop.learning.esp.solid.request.strategy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.AddRequestServices();

using IHost host = builder.Build();

// Ejemplo de uso: Construcción y procesamiento de un request
IRequestBuilder requestBuilder = host.Services.GetRequiredService<IRequestBuilder>();
Request medicationRequest = requestBuilder
                                .AssociateRequestType(ERequestType.MEDICATION)
                                .AddAttachment(new Document(EDocumentType.INVOICE, "Invoice content"))
                                .AssignAmmount(100)
                                .AssignPatient(new Patient("John Doe", "12345678"))
                                .AssignProvider(new Provider("HealthCare Inc.", "87654321"))
                                .Build();

StateExecutorContext executorContext = host.Services.GetRequiredService<StateExecutorContext>();
ExecutorFacade executorFacade = new(executorContext);
do
{
    Console.WriteLine($"Procesando request con estado inicial: {medicationRequest.State}");
    medicationRequest = executorFacade.Execute(medicationRequest);
    Console.WriteLine($"Request procesado con estado: {medicationRequest.State}");
}while (executorFacade.GetPendingStates(medicationRequest).Any() 
    || (medicationRequest.State != ERequestState.APPROVED
        && medicationRequest.State != ERequestState.REJECTED));

Console.WriteLine("Presione Enter para finalizar...");
Console.ReadLine();

await host.RunAsync();


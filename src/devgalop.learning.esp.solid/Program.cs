
using devgalop.learning.esp.solid.request;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.AddRequestServices();

using IHost host = builder.Build();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();

await host.RunAsync();
// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.DependencyInjection;
using MSS.Service.Services.Classes;
using MSS.Service.Services.Interfaces;
using RabbitMQ.Client;

var serviceProvider = new ServiceCollection()
           .AddTransient<ICoreService, CoreService>()
           .AddTransient<IMessageService, RabbitMqMessageService>()
           .AddSingleton<ConnectionFactory>(s => new ConnectionFactory() { HostName = "localhost" })
           .BuildServiceProvider();

//do the actual work here
var core = serviceProvider.GetService<ICoreService>();
core.Run();
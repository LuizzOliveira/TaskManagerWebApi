using TaskManager.API.Extensions;
using TaskManager.Application.Extensions;
using TaskManager.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();

builder.Services
    .AddUseCases()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.AddEndpoints();

app.UseServices();

app.Run();
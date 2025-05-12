using TaskManager.API.Extensions;
using TaskManager.Application.Extensions;
using TaskManager.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

builder.AddServices();
builder.Services
    .AddUseCases();

var app = builder.Build();

app.AddEndpoints();
app.UseServices();

app.Run();
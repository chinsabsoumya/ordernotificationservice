using FluentValidation;
using Order.API.Endpoints;
using Order.Application.Commands;
using Order.Application.Validators;
using Order.Infrastructure.Dependencyinjection;
using SQLitePCL;

Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();


builder.Services.AddInfratructure(builder.Configuration);
builder.Services.AddMediatR(c =>
{
    c.RegisterServicesFromAssemblies(typeof(CreateOrderCommand).Assembly);
});
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapOrderEndpoint();

app.Run();

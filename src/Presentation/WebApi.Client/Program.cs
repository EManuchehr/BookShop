using Application.Client;
using Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication().AddJwtBearer("LocalAuthIssuer");
builder.Services.AddAuthorization();
builder.Services.AddClientPersistenceInfrastructureLayer(builder.Configuration);
builder.Services.AddApplicationClientLayer(builder.Configuration);
builder.Services.AddClientEndpoints();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseClientEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/hello", () => "Hello world!").RequireAuthorization();
app.MapGet("/test", () => "Hello world!").WithOpenApi();

app.Run();
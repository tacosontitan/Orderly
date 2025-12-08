using Orderly.Risk;
using Orderly.Risk.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
RegisterServices(builder.Services);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/risk", Endpoints.EvaluateRisk).WithName("EvaluateRisk");
app.Run();

static void RegisterServices(IServiceCollection services) => services
	.AddOpenApi()
	.AddRiskServices();
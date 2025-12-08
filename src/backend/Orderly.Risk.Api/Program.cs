using Orderly.Customers;
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
RegisterEndpoints(app);
app.Run();

static void RegisterEndpoints(WebApplication app)
{
	app.MapGet("/risk", Endpoints.EvaluateRisk).WithName("EvaluateRisk");
}

static void RegisterServices(IServiceCollection services) => services
	.AddOpenApi()
	.AddRiskServices()
	.AddCustomerServices();
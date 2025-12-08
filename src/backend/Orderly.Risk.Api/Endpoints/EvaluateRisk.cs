using Microsoft.AspNetCore.Mvc;
using Orderly.Risk.Contracts;

namespace Orderly.Risk.Api.Endpoints;

internal static partial class Endpoints
{
	internal static async Task<IResult> EvaluateRisk(
		[FromQuery] Guid requestId,
		[FromQuery] Guid customerId,
		[FromQuery] decimal cost,
		[FromServices] IRiskService riskService,
		CancellationToken cancellationToken
	)
	{
		if (requestId == Guid.Empty)
		{
			RiskResponse response = new(requestId, false, 1.0, "A request ID is required to assess risk.");
			return Results.BadRequest(response);
		}

		if (customerId == Guid.Empty)
		{
			RiskResponse response = new(requestId, false, 1.0, "A customer ID is required to assess risk.");
			return Results.BadRequest(response);
		}

		if (cost <= 0)
		{
			RiskResponse response = new(requestId, false, 1.0, "The cost must be greater than zero to assess risk.");
			return Results.BadRequest(response);
		}

		RiskRequest request = new(requestId, customerId, cost);
		RiskResponse riskResponse = await riskService.EvaluateRisk(request, cancellationToken);
		return Results.Ok(riskResponse);
	}
}
using Orderly.Risk.Contracts;

namespace Orderly.Risk.Api.Endpoints;

internal static partial class Endpoints
{
	internal static async Task<IResult> EvaluateRisk(RiskRequest request, IRiskService riskService)
	{
		if (request is null)
		{
			RiskResponse response = new(Guid.Empty, false, 1.0, "Unable to assess risk without a properly formed request.");
			return Results.BadRequest(response);
		}

		if (request.RequestId == Guid.Empty)
		{
			RiskResponse response = new(request.RequestId, false, 1.0, "A request ID is required to assess risk.");
			return Results.BadRequest(response);
		}

		if (request.CustomerId == Guid.Empty)
		{
			RiskResponse response = new(request.RequestId, false, 1.0, "A customer ID is required to assess risk.");
			return Results.BadRequest(response);
		}

		RiskResponse riskResponse = await riskService.EvaluateRisk(request);
		return Results.Ok(riskResponse);
	}
}
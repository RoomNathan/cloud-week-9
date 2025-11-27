using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function;

public class GetFoods
{
    private readonly ILogger<GetFoods> _logger;
    private readonly IFoodService _foodService;

    public GetFoods(ILogger<GetFoods> logger, IFoodService foodService)
    {
        _logger = logger;
        _foodService = foodService;
    }

    [Function("GetFoods")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "foods")] HttpRequest req)
    {
        var foods = _foodService.GetAllFood().Result;
        return new OkObjectResult(foods);
    }
}
using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;
using FastFood.Models;
using FastFood.Services.FastFood;

namespace FastFood.Controllers
{
    [ApiController]
    [Route("/fastfood")]
    public class FastFoodController : ControllerBase
    {
        private readonly IFastFoodService _fastfoodService;

        public FastFoodController(IFastFoodService fastfoodService)
        {
            _fastfoodService = fastfoodService;
        }

        [HttpPost]
        public IActionResult CreateFastFood(CreateFastFoodRequest request)
        {
            var fastfood = new FastFoodModel(Guid.NewGuid(), request.Name, request.Description, request.StartDate, request.EndDate, DateTime.UtcNow, request.Savory, request.Sweet);

            _fastfoodService.CreateFastFood(fastfood);

            var response = new FastFoodResponse(fastfood.Id, fastfood.Name, fastfood.Description, fastfood.StartDate, fastfood.EndDate, fastfood.LastModifiedDateTime, fastfood.Savory, fastfood.Sweet);
            return CreatedAtAction(
                actionName: nameof(GetFastFood),
                routeValues: new { id = response.Id },
                value: response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetFastFood(Guid Id)
        {
            var fastfood = _fastfoodService.GetFastFood(Id);

            var response = new FastFoodResponse(
                fastfood.Id,
                fastfood.Name,
                fastfood.Description,
                fastfood.StartDate,
                fastfood.EndDate,
                fastfood.LastModifiedDateTime,
                fastfood.Savory,
                fastfood.Sweet);

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertFastFood(Guid Id, UpsertFastFoodResquest request)
        {
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFastFood(Guid Id)
        {
            return Ok(Id);
        }
    }
}
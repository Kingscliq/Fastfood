using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;
using FastFood.Models;
using FastFood.Services.FastFood;
using ErrorOr;
using FastFood.ServiceErrors;

namespace FastFood.Controllers
{
    public class FastFoodController : ApiController
    {
        private readonly IFastFoodService _fastfoodService;

        public FastFoodController(IFastFoodService fastfoodService)
        {
            _fastfoodService = fastfoodService;
        }

        [HttpPost]
        public IActionResult CreateFastFood(CreateFastFoodRequest request)
        {
            var fastfood = new FastFoodModel(
                Guid.NewGuid(),
                request.Name,
                request.Description,
                request.StartDate,
                request.EndDate,
                DateTime.UtcNow,
                request.Savory,
                request.Sweet);

            _fastfoodService.CreateFastFood(fastfood);

            var response = new FastFoodResponse(fastfood.Id,
             fastfood.Name,
             fastfood.Description,
             fastfood.StartDate,
             fastfood.EndDate,
             fastfood.LastModifiedDateTime,
             fastfood.Savory,
             fastfood.Sweet);

            return CreatedAtAction(
                actionName: nameof(GetFastFood),
                routeValues: new { id = response.Id },
                value: response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetFastFood(Guid Id)
        {
            ErrorOr<FastFoodModel> getFastFoodResult = _fastfoodService.GetFastFood(Id);

            return getFastFoodResult.Match(
                fastfood => Ok(MapFastFoodResponse(fastfood)),
                error => Problem());
            // return 
            // if (getFastFoodResult.IsError && getFastFoodResult.FirstError == Errors.FastFood.NotFound)
            // {
            //     return NotFound();
            // }

            // var fastfood = getFastFoodResult.Value;
            // FastFoodResponse response = MapFastFoodResponse(fastfood);

            // return Ok(response);
        }

        private static FastFoodResponse MapFastFoodResponse(FastFoodModel fastfood)
        {
            return new FastFoodResponse(
                            fastfood.Id,
                            fastfood.Name,
                            fastfood.Description,
                            fastfood.StartDate,
                            fastfood.EndDate,
                            fastfood.LastModifiedDateTime,
                            fastfood.Savory,
                            fastfood.Sweet);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertFastFood(Guid Id, UpsertFastFoodResquest request)
        {
            var fastfood = new FastFoodModel(
              Id,
              request.Name,
              request.Description,
              request.EndDate,
              request.StartDate,
              DateTime.UtcNow,
              request.Savory,
              request.Sweet
            );

            _fastfoodService.UpsertFastFood(fastfood);

            // TODO: Return 201 Created if the Item's ID doesnt exist on the DB 
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFastFood(Guid Id)
        {
            _fastfoodService.DeleteFastFood(Id);
            return Ok(Id);
        }
    }
}
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
            ErrorOr<FastFoodModel> requestForFastFood = FastFoodModel.From(request);

            if (requestForFastFood.IsError)
                return Problem(requestForFastFood.Errors);

            var fastfood = requestForFastFood.Value;

            ErrorOr<Created> createFastFoodResult = _fastfoodService.CreateFastFood(fastfood);

            return createFastFoodResult.Match(
                _ => CreatedAtUpdatedFastFood(fastfood),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetFastFood(Guid Id)
        {
            ErrorOr<FastFoodModel> getFastFoodResult = _fastfoodService.GetFastFood(Id);

            return getFastFoodResult.Match(
                fastfood => Ok(MapFastFoodResponse(fastfood)),
                errors => Problem(errors));
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetAllFastFood()
        {
            ErrorOr<FastFoodModel> getAllFastFoodResult = _fastfoodService.GetFastFood(Id);

            return getAllFastFoodResult.Match(
                fastfood => Ok(MapFastFoodResponse(fastfood)),
                errors => Problem(errors));
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertFastFood(Guid Id, UpsertFastFoodResquest request)
        {
            var requestToUpdate = FastFoodModel.From(Id, request);
        if(requestToUpdate.IsError)
        return Problem(requestToUpdate.Errors);

        var fastfood = requestToUpdate.Value;
            ErrorOr<UpsertedFastFood> updateFastFoodResult = _fastfoodService.UpsertFastFood(fastfood);

            return updateFastFoodResult.Match(
             updated => updated.IsNewlyCreated ? CreatedAtUpdatedFastFood(fastfood) : NoContent(),
             errors => Problem(errors)
            );
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFastFood(Guid Id)
        {
            ErrorOr<Deleted> deletedResult = _fastfoodService.DeleteFastFood(Id);

            return deletedResult.Match(
                 _ => NoContent(),
                 errors => Problem(errors)
             );
        }

        // Abstracting fast Food Response
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

        private IActionResult CreatedAtUpdatedFastFood(FastFoodModel fastfood)
        {
            return CreatedAtAction(
                actionName: nameof(GetFastFood),
                routeValues: new { id = fastfood.Id },
                value: MapFastFoodResponse(fastfood));
        }
    }
}

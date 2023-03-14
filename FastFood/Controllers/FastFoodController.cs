using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;
using FastFood.Models;

namespace FastFood.Controllers
{
    [ApiController]
    [Route("/fastfood")]
    public class FastFoodController : ControllerBase
    {

        [HttpPost()]
        public IActionResult CreateFastFood(CreateFastFoodRequest request){
            var fastfood = new FastFoodModel(Guid.NewGuid(), request.Name, request.Description, request.StartDate, request.EndDate, DateTime.UtcNow, request.Savory, request.Sweet);

            // TODO: Save Information to DB

            var response = new FastFoodResponse(fastfood.Id, fastfood.Name, fastfood.Description, fastfood.StartDate, fastfood.EndDate, fastfood.LastModifiedDateTime, fastfood.Savory, fastfood.Sweet);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetFastFood(Guid Id){
            return Ok(Id);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpsertFastFood(Guid Id, UpsertFastFoodResquest request){
            return Ok(request);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteFastFood(Guid Id){
            return Ok(Id);
        }
    }
}
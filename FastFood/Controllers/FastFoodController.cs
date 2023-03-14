using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;

namespace FastFood.Controllers
{
    [ApiController]
    [Route("/fastfood")]
    public class FastFoodController : ControllerBase
    {

        [HttpPost()]
        public IActionResult CreateFastFood(CreateFastFoodRequest request){
            return Ok(request);
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
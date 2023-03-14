using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;

namespace FastFood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FastFoodController : ControllerBase
    {
        

        [HttpPost("/fastfood")]
        public IActionResult CreateFastFood(CreateFastFoodRequest request){
            return Ok(request);
        }

        [HttpGet("/fastfood/{guid:id}")]
        public IActionResult GetFastFood(Guid Id){
            return Ok(Id);
        }


        [HttpPut("/fastfood/{guid:id}")]
        public IActionResult UpsertFastFoodRequest(Guid Id, UpsertFastFoodResquest request){
            return Ok(request);
        }

        [HttpPut("/fastfood/{guid:id}")]
        public IActionResult DeleteFastFood(Guid Id, UpsertFastFoodResquest request){
            return Ok(request);
        }
    }
}
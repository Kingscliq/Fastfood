using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FastFood.Contracts.FastFood;

namespace FastFood.Controllers
{
    [ApiController]
    public class FastFoodController : ControllerBase
    {

        [HttpPost("/fastfood")]
        public IActionResult CreateFastFood(CreateFastFoodRequest request){
            return Ok(request);
        }

        [HttpGet("/fastfood/{id:guid}")]
        public IActionResult GetFastFood(Guid Id){
            return Ok(Id);
        }


        [HttpPut("/fastfood/{id:guid}")]
        public IActionResult UpsertFastFood(Guid Id, UpsertFastFoodResquest request){
            return Ok(request);
        }

        [HttpDelete("/fastfood/{id:guid}")]
        public IActionResult DeleteFastFood(Guid Id){
            return Ok(Id);
        }
    }
}
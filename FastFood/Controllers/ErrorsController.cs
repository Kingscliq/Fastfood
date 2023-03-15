using Microsoft.AspNetCore.Mvc;

namespace FastFood.Controllers;

public class ErrorsController: ControllerBase{
    [Route("/error")]
    public IActionResult Errors(){
        return Problem();
    }
}
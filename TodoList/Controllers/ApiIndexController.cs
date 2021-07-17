using System;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace TodoListt.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ApiIndexController : Controller
    {
        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            return Json(new { Docs = new { Swagger = new Uri(HttpContext.Request.GetDisplayUrl() + "swagger") } });
        }
    }
}
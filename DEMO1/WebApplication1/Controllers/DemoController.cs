using Demo.Demo.BO;
using Demo.Demo.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DemoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<DemoController> _logger;
        private readonly IDemoService _demoService;
        public DemoController(ILogger<DemoController> logger, IDemoService demoService)
        {
            _logger = logger;
            _demoService = demoService;
        }


        [HttpPost("", Name = "CreateCustomer")]
        public IActionResult Post([FromBody] CustomerBO customer)
        {
            try
            {

                _demoService.CreateCustomer(customer);
                return Ok(true);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
            }

            return Ok(false);
        }
    }
}
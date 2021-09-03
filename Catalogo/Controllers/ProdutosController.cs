using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalogo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ILogger<ProdutosController> _logger;

        public ProdutosController(ILogger<ProdutosController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Acionando controller");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            _logger.LogInformation("Obtendo produtos");
            return Ok("Produto x");
        }
    }
}

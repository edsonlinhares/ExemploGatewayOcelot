using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Vendas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;

        public PedidosController(ILogger<PedidosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Pedido Um");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok($"Pedido {id}");
        }
    }
}

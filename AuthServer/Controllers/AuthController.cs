using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private IOptions<Audience> _settings;

        public AuthController(ILogger<AuthController> logger, IOptions<Audience> settings)
        {
            _logger = logger;
            _settings = settings;
        }


        [HttpGet]
        public IActionResult Get(string name, string pwd)
        {
            var _repository = new UserRepository();
            var _user = _repository.Get(name, pwd);

            if (_user != null)
            {
                var _tokenService = new TokenService(_settings);

                return Ok(_tokenService.GenerateToken(_user));
            }

            return BadRequest();
        }



    }
}

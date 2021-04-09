using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsTest.Helpers;
using wsTest.Models.Data;
using wsTest.Models.Services.Datas;

namespace wsTest.Controllers
{
    [Route("ws")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        IDBService _myDb;
        private readonly ILogger<ServiceController> _logger;

        public ServiceController(ILogger<ServiceController> logger, IDBService db)
        {
            _myDb = db;
            _logger = logger;
        }

        [HttpPost("userLogin")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
        public async Task<ActionResult<LoginResult>> userLogin([FromBody]Login credentials)
        {
            LoginResult res;
            res = await _myDb.login(credentials);
            return Ok(res);
        }

        [Authorize]
        [HttpGet("userList")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResult))]
        public async Task<ActionResult<LoginResult>> userList()
        {
            List<User> res = new List<User>();
            res = await _myDb.GetAll();
            return Ok(res);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorLogController : ControllerBase
    {
        private IErrorLogService _errorLogService;
        public ErrorLogController(IErrorLogService errorLogService)
        {
            _errorLogService = errorLogService;
        }

        [HttpPost("add")]
        public IActionResult Add(ErrorLog errorLog)
        {
            var result = _errorLogService.Add(errorLog);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}

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

        [HttpGet("getall")]
        [Authorize(Roles = "Product.List")]
        public IActionResult GetList()
        {
            var result = _errorLogService.GetList();

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyerrorlogid")]
        public IActionResult GetByErrorLogId(int errorLogId)
        {
            var result = _errorLogService.GetById(errorLogId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
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

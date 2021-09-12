using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBlockedUserController : ControllerBase
    {
        private IUserBlockedUserMappingService _userBlockedUserMapping;
        public UserBlockedUserController(IUserBlockedUserMappingService userBlockedUserMapping)
        {
            _userBlockedUserMapping = userBlockedUserMapping;
        }

        [HttpGet("getbyblockeduserid")]
        public IActionResult GetByBlockedUserId(int blockedUserId)
        {
            var result = _userBlockedUserMapping.GetByBlockerUserId(blockedUserId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("block")]
        public IActionResult Block(BlockUserDto blockUser)
        {
            var result = _userBlockedUserMapping.Block(blockUser.UserToBlock, blockUser.CurrentUserId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
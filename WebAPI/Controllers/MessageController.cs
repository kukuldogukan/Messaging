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
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("getbyreceiveruserid")]
        public IActionResult GetByReceiverUserId(int receiverUserId)
        {
            var result = _messageService.GetByReceiverUserId(receiverUserId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbysenderuserid")]
        public IActionResult GetBySenderUserId(int senderUserId)
        {
            var result = _messageService.GetBySenderUserId(senderUserId);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("send")]
        public IActionResult Add(SendMessageDto sendMessageDto)
        {
            var result = _messageService.Send(sendMessageDto.ReceiverUserCode, sendMessageDto.SenderUserCode, sendMessageDto.Message);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class SendMessageDto : IDto
    {
        public string ReceiverUserCode { get; set; }
        public string SenderUserCode { get; set; }
        public string Message { get; set; }
    }
}

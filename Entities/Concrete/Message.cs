using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Message : IEntity
    {
        [Key()]
        public int MessageHistoryId { get; set; }
        public int ReceiverUserId { get; set; }
        public int SenderUserId { get; set; }
        public string MessageText { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

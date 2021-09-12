using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace Entities.Concrete
{
    public class ErrorLog : IEntity
    {
        [Key()]
        public int ErrorLogId { get; set; }
        public int UserId { get; set; }
        public string ErrorMessage{ get; set; }
        public DateTime CreateDate { get; set; }
    }
}

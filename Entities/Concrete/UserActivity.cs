using System;
using System.ComponentModel.DataAnnotations;
using Core.Entities;
using Entities.Concrete.Enums;

namespace Entities.Concrete
{
    public class UserActivity : IEntity
    {
        [Key()]
        public int UserActivityId { get; set; }
        public UserActivities ActivityId{ get; set; }
        public DateTime CreateDate { get; set; }
    }
}

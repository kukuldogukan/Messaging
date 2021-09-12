using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class UserBlockedUserMapping :IEntity
    {
        public int UserBlockedUserMappingId { get; set; }
        public int BlockerUserId { get; set; }
        public int BlockedUserId { get; set; }
    }
}

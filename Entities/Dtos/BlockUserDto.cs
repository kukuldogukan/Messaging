using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Dtos
{
    public class BlockUserDto : IDto
    {
        public string UserToBlock { get; set; }
        public int CurrentUserId{ get; set; }
    }
}

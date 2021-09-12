using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserBlockedUserMappingService
    {
        IDataResult<UserBlockedUserMapping> GetByBlockerUserId(int blockerUserId);
        IResult Block(string userCodeToBlock, int currentUserId);
        bool IsUserBlocked(int blockedUserId, int currentUserId);
    }
}

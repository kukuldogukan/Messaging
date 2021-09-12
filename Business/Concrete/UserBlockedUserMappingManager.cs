using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserBlockedUserMappingManager : IUserBlockedUserMappingService
    {
        private IUserBlockedUserMappingDal _userBlockedUserMapping;
        private IUserService _userService;
        public UserBlockedUserMappingManager(IUserBlockedUserMappingDal userBlockedUserMapping, IUserService userService)
        {
            _userBlockedUserMapping = userBlockedUserMapping;
            _userService = userService;
        }

        public IDataResult<List<UserBlockedUserMapping>> GetListByBlockerUserId(int blockerUserId)
        {
            return new SuccessDataResult<List<UserBlockedUserMapping>>(_userBlockedUserMapping.GetList(p => p.BlockerUserId == blockerUserId).ToList());
        }

        public IDataResult<UserBlockedUserMapping> GetByBlockerUserId(int blockerUserId)
        {
            return new SuccessDataResult<UserBlockedUserMapping>(_userBlockedUserMapping.Get(p => p.BlockerUserId == blockerUserId));
        }

        public bool IsUserBlocked(int blockedUserId, int currentUserId)
        {
            var mapping = GetListByBlockerUserId(currentUserId).Data?.Select(t => t.BlockedUserId);
            if (mapping.Contains(blockedUserId))
            {
                return true;
            }

            return false;
        }

        public IResult Block(string userCodeToBlock, int currentUserId)
        {
            var userToBlock = _userService.GetByUserCode(userCodeToBlock);
            if (IsUserBlocked(userToBlock.Id, currentUserId))
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            _userBlockedUserMapping.Add(new UserBlockedUserMapping
            {
                BlockedUserId = userToBlock.Id,
                BlockerUserId = currentUserId
            });

            return new SuccessResult(Messages.UserBlocked);
        }
    }
}

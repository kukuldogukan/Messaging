using System;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;
        private IUserBlockedUserMappingService _blockedUserMappingService;
        private IErrorLogService _errorLogService;
        private IUserService _userService;

        public MessageManager(IMessageDal messageHistoryDal, IUserBlockedUserMappingService userBlockedUserMappingService, IErrorLogService errorLogService, IUserService userService)
        {
            _messageDal = messageHistoryDal;
            _errorLogService = errorLogService;
            _blockedUserMappingService = userBlockedUserMappingService;
            _userService = userService;
        }

        public IDataResult<Message> GetByReceiverUserId(int receiverUserId)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(p => p.ReceiverUserId == receiverUserId));
        }

        public IDataResult<Message> GetBySenderUserId(int senderUserId)
        {
            return new SuccessDataResult<Message>(_messageDal.Get(p => p.SenderUserId == senderUserId));
        }

        public IResult Send(string receiverUserCode, string senderUserCode, string message)
        {
            var receiverUser = _userService.GetByUserCode(receiverUserCode);
            var senderUser = _userService.GetByUserCode(senderUserCode);
            var isUserBlocked = _blockedUserMappingService.IsUserBlocked(senderUser.Id, receiverUser.Id);

            if (isUserBlocked)
            {
                _errorLogService.Add(new ErrorLog
                {
                    UserId = senderUser.Id,
                    ErrorMessage = Messages.CanNotSendMessageDueToTheBlock,
                    CreateDate = DateTime.Now
                });

                return new ErrorResult(Messages.CanNotSendMessageDueToTheBlock);
            }
            _messageDal.Add(new Message
            {
                ReceiverUserId = receiverUser.Id,
                SenderUserId = senderUser.Id,
                CreateDate = DateTime.Now,
                MessageText = message
            });
            return new SuccessResult(Messages.MessageSent);
        }
    }
}

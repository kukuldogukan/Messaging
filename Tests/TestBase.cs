using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Moq;
using System;
using Castle.Core.Internal;

namespace Tests
{
    public class TestBase
    {
        internal Mock<IMessageService> messageService = new Mock<IMessageService>();
        internal Mock<IUserService> userService = new Mock<IUserService>();
        internal Mock<IUserBlockedUserMappingService> blockerUserService = new Mock<IUserBlockedUserMappingService>();
        internal Mock<IErrorLogService> errorLogService = new Mock<IErrorLogService>();
        internal Message MockMessage(int receiverUserId, int senderUserId, string messageText)
        {
            var message = new Message
            {
                MessageHistoryId = 1,
                ReceiverUserId = receiverUserId,
                SenderUserId = senderUserId,
                MessageText = messageText,
                CreateDate = DateTime.Now
            };

            messageService.Setup(t => t.GetByReceiverUserId(receiverUserId))
                .Returns(new DataResult<Message>(message, true));
            messageService.Setup(t => t.GetBySenderUserId(senderUserId))
                .Returns(new DataResult<Message>(message, true));

            return message;

        }

        internal User SetupUser(string userCode, string email = default)
        {
            var user = new User
            {
                UserCode = userCode,
                Email = email
            };

            userService.Setup(t => t.GetByUserCode(userCode)).Returns(user);
            if (!email.IsNullOrEmpty())
            {
                userService.Setup(t => t.GetByMail(email)).Returns(user);
            }
            return user;
        }

        internal void AddUserBlockedUserMapping(int blocker, int receiver)
        {
            var result = new UserBlockedUserMapping
            {
                BlockerUserId = blocker,
                BlockedUserId = receiver
            };
            blockerUserService.Setup(t => t.GetByBlockerUserId(blocker))
                .Returns(() => new DataResult<UserBlockedUserMapping>(result, true));
            blockerUserService.Setup(t => t.IsUserBlocked(receiver, blocker)).Returns(false);
            errorLogService.Setup(t => t.Add(It.IsAny<ErrorLog>())).Returns(() => new Result(true));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IMessageService
    {
        IResult Send(string receiverUserCode, string senderUserCode, string message);
        IDataResult<Message> GetByReceiverUserId(int receiverUserId);
        IDataResult<Message> GetBySenderUserId(int senderUserId);
    }
}

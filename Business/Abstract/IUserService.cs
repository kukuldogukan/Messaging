using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        void Add(User user);
        User GetByMail(string email);
        User GetByUserCode(string userCode);

    }
}

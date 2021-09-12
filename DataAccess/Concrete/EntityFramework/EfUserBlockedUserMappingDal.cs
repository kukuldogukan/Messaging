using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserBlockedUserMappingDal : EfEntityRepositoryBase<UserBlockedUserMapping>,
        IUserBlockedUserMappingDal
    {
        private MessagingContext _context;
        public EfUserBlockedUserMappingDal(MessagingContext context) : base(context)
        {
            _context = context;
        }
    }
}

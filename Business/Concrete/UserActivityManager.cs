using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserActivityManager : IUserActivityService
    {
        private IUserActivityDal _userActivityDal;
        private IUserService _userService;
        public UserActivityManager(IUserActivityDal userActivityDal, IUserService userService)
        {
            _userActivityDal = userActivityDal;
            _userService = userService;
        }

        public IResult Add(UserActivity userActivity)
        {
            _userActivityDal.Add(userActivity);
            return new SuccessResult(Messages.UserActivityAdded);
        }
    }
}

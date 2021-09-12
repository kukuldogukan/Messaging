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
        public UserActivityManager(IUserActivityDal userActivityDal)
        {
            _userActivityDal = userActivityDal;
        }

        public IResult Add(UserActivity userActivity)
        {
            _userActivityDal.Add(userActivity);
            return new SuccessResult(Messages.UserActivityAdded);
        }
    }
}

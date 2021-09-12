using System;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Entities.Concrete;
using Entities.Concrete.Enums;
using Entities.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private IUserActivityService _userActivity;


        public AuthManager(IUserService userService,  IUserActivityService userActivity)
        {
            _userService = userService;

            _userActivity = userActivity;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                UserCode = userForRegisterDto.UserCode,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };
            _userService.Add(user);
            _userActivity.Add(new UserActivity
            {
                ActivityId = UserActivities.Register,
                CreateDate = DateTime.Now
            });
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                _userActivity.Add(new UserActivity
                {
                    ActivityId = UserActivities.InvalidLogin,
                    CreateDate = DateTime.Now
                });
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                _userActivity.Add(new UserActivity
                {
                    ActivityId = UserActivities.InvalidLogin,
                    CreateDate = DateTime.Now
                });
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            _userActivity.Add(new UserActivity
            {
                ActivityId = UserActivities.ValidLogin,
                CreateDate = DateTime.Now
            });
            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}

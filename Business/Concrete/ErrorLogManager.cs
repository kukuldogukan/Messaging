using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ErrorLogManager : IErrorLogService
    {
        private IErrorLogDal _errorLogDal;

        public ErrorLogManager(IErrorLogDal errorLogDal)
        {
            _errorLogDal = errorLogDal;
        }

        public IResult Add(ErrorLog errorLog)
        {
            _errorLogDal.Add(errorLog);
            return new SuccessResult(Messages.ErrorLogAdded);
        }
    }
}

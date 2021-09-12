using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class ErrorLogManager : IErrorLogService
    {
        private IErrorLogDal _errorLogDal;

        public ErrorLogManager(IErrorLogDal errorLogDal)
        {
            _errorLogDal = errorLogDal;
        }


        public IDataResult<ErrorLog> GetById(int errorLogId)
        {
            return new SuccessDataResult<ErrorLog>(_errorLogDal.Get(p => p.ErrorLogId == errorLogId));
        }

        public IDataResult<List<ErrorLog>> GetList()
        {
            return new SuccessDataResult<List<ErrorLog>>(_errorLogDal.GetList().ToList());
        }

        public IResult Add(ErrorLog errorLog)
        {
            _errorLogDal.Add(errorLog);
            return new SuccessResult(Messages.ErrorLogAdded);
        }
    }
}

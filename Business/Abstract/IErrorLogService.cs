using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IErrorLogService
    {
        IDataResult<ErrorLog> GetById(int errorLogId);
        IDataResult<List<ErrorLog>> GetList();
        IResult Add(ErrorLog errorLog);
    }
}

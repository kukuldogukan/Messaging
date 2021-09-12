using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserActivityService
    {
        IResult Add(UserActivity userActivity);
    }
}

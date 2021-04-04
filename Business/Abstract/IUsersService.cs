﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUsersService
    {
        IResult Add(Users user);
        IResult Delete(Users user);
        IResult Update(Users user);
        IDataResult<List<Users>> GetAll();
        IDataResult<List<Users>> GetAllById(int id);
    }
}
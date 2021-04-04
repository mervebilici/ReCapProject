using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Update(Customers customers);
        IResult Delete(Customers customers);
        IResult Add(Customers customers);
        DataResult<List<Customers>> GetAll();
        IDataResult<List<Customers>> GetAllById(int Id);
    }
}

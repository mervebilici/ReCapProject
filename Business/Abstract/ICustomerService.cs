using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IResult Add(Customer customer);
        DataResult<List<Customer>> GetAll();
        IDataResult<List<Customer>> GetAllById(int Id);
    }
}

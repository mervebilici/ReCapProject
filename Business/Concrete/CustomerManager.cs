using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomersDal _customersDal;

        public CustomerManager(ICustomersDal customersDal)
        {
            _customersDal = customersDal;
        }

        public IResult Add(Customers customers)
        {
            _customersDal.Add(customers);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Customers customers)
        {
            _customersDal.Delete(customers);
            return new SuccessResult(Messages.Deleted);
        }

        public DataResult<List<Customers>> GetAll()
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll());
        }

        public IDataResult<List<Customers>> GetAllById(int Id)
        {
            return new SuccessDataResult<List<Customers>>(_customersDal.GetAll(p => p.UserId == Id));
        }

        public IResult Update(Customers customers)
        {
            _customersDal.Update(customers);
            return new SuccessResult(Messages.Updated);
        }
    }
}

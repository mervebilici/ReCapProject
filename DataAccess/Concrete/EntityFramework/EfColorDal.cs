using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Entities.Concrete.Color, CarRentalContext>, IColorDal
    {
        public List<ColorDetailDto> GetColorDetails()
        {
            throw new NotImplementedException();
        }
    }
}

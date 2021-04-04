using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService:IService<Entities.Concrete.Brand>
    {
        IDataResult<List<BrandDetailDto>> GetBrandDetails();
        
    }
}

﻿using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService:IService<Entities.Concrete.Brand>
    {
        List<BrandDetailDto> GetBrandDetails();
    }
}

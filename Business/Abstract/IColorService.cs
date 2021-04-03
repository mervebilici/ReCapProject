using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService: IService<Entities.Concrete.Color>
    {
        List<ColorDetailDto> GetColorDetails();
    }
}

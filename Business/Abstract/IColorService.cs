using Core.Utilities.Results;
using Entities.DTOs;
using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<ColorDetailDto>> GetColorDetails();
        IDataResult<List<Entities.Concrete.Color>> GetAll();

        IResult Update(Entities.Concrete.Color colors);
        IResult Delete(Entities.Concrete.Color colors);
        IResult Add(Entities.Concrete.Color colors);

        IDataResult<List<Entities.Concrete.Color>> GetAllById(int colorId);
        
    }
}

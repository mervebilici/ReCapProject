﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T> 
    {
        List<T> GetAll();
       
    }
}
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("GİRİLEN MARKA İSMİ 2 KARAKTERDEN KÜÇÜK. LÜTFEN GEÇERLİ BİR MARKA İSMİ GİRİNİZ.");
            }
        }

        public void Delete(Brand brand)
        {

           _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
    }

        public List<BrandDetailDto> GetBrandDetails()
        {
            return _brandDal.GetBrandDetails();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}

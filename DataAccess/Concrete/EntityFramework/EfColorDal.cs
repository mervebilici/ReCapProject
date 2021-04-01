using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfColorDal : IColorDal
    {
        public void Add(Entities.Concrete.Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(Entities.Concrete.Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Entities.Concrete.Color Get(Expression<Func<Entities.Concrete.Color, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Entities.Concrete.Color>().SingleOrDefault(filter);
            }
        }

        public List<Entities.Concrete.Color> GetAll(Expression<Func<Entities.Concrete.Color, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return filter == null
                ? context.Set<Entities.Concrete.Color>().ToList()
                : context.Set<Entities.Concrete.Color>().Where(filter).ToList();
            }
        }

        public void Update(Entities.Concrete.Color entity)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}

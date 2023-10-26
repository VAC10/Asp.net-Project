using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{//NuGet
    public class EfProductDal : IProductDal
    {
        public void add(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity= context.Entry(entity);// veri kaynağına gidip referansı yakaladım
                addedEntity.State = EntityState.Added;// yapılacak operasyonu belirttim(add)
                context.SaveChanges();  
            }
        }

        public void delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);// veri kaynağına gidip referansı yakaladım
                deletedEntity.State = EntityState.Deleted;// yapılacak operasyonu belirttim(delete)
                context.SaveChanges();
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList()// filtre null ise bu çalışır
                    :context.Set<Product>().Where(filter).ToList();// değilse filtreleyip ver
            }
        }

        public void update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);// veri kaynağına gidip referansı yakaladım
                updatedEntity.State = EntityState.Modified;// yapılacak operasyonu belirttim(update)
                context.SaveChanges();
            }
        }
    }
}

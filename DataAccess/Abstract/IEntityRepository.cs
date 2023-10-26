using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{// GENERİC CONSTRAİNT
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    // new()=newlenebilir olmalı
    public interface IEntityRepository <T> where T:class,IEntity,new()  
    {
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void add(T entity);

        void update(T entity);

        void delete(T entity);

        




    }
}

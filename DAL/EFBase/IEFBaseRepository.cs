using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL.EFBase
{
    public interface IEFBaseRepository<T> where T : class
    {
        // Tüm Repositorylerde kullanacağımız ortak metotları Interface de topladık. Bu sayede kod tekrarının önüne geçildi.
        T Add(T entity);
        T Update(T entity);
        IEnumerable<T> GetAll(Expression<Func<T,bool>> expression = null);  // GetAll() da koşullu sorgula yazabilmemiz için Linq ların expressionlarından yararlanıyoruz.
        void Delete(T entity);
        T Get(Expression<Func<T,bool>> expression);
        void SaveChanges();

    }
}

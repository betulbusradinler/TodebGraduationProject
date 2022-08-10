using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EFBase
{
    public class EFBaseRepository<T, TBContext> : IEFBaseRepository<T> 
        where T : class
        where TBContext: DbContext  // Contexti ne olduğunu belirttik 
    {
        protected TBContext Context;  
        public EFBaseRepository(TBContext context)
        {
            Context = context;
        }

        public T Add(T entity)
        {
            return Context.Entry(entity).Entity; // Burdaki Entry sayesinde hangi tabloyu kullanacağını kendisi çözüyor.

        }

        public T Update(T entity)
        {
            Context.Update(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            Context.Remove(entity); 
        }

        public T Get(Expression<Func<T, bool>> expression)  //Burada bir koşulum yok ve 1 tane sonuc bekliyorum
        {
            return Context.Set<T>().FirstOrDefault(expression);
        }
        /// <summary>
        ///  Null ise bütün dataları dönecek, değil ise koşulu sağlayan datalar dönecek
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if(expression == null)
                return Context.Set<T>().ToList();
            else
            {
                return Context.Set<T>().Where(expression);
            }
        }

        public void SaveChanges()
        {
        }

    }
}

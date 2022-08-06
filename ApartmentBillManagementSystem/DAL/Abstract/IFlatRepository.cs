using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IFlatRepository
    {
        /*
         * Daire ile ilgili işlemler: 
         * Daire bilgilerini girebiliyor. 
         * Daire başına ödenmesi gereken fatura bilgilerini girer. Toplu ya da ayrı ayrı olarak
         *  Daire/konut bilgilerini listeler, düzenler siler.
         */
        public IEnumerable<Flat> GetAll();

        public void Add(Flat flat);
        public void Update(Flat flat);
        public void Delete(Flat flat);
    }
}

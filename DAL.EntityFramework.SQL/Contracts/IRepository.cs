using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFramework.SQL
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string id); 
        T Find(string id);
        T FindHeadline(string Headline);
        void Insert(T t);
        void Update(T t);
    }
}

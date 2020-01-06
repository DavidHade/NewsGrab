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
        void Delete(string id); // TODO - Id column in database is int
        T Find(string id); // TODO - Id column in database is int
        T FindHeadline(string Headline);
        void Insert(T t);
        void Update(T t);
    }
}

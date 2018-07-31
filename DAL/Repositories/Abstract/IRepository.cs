using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICPartners.DAL.Repositories.Abstract
{
    public interface IRepository<TEntity> where TEntity:class
    {
        TEntity GetByID(int id);
        IEnumerable<TEntity> GetAll();
        void Add( TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(int id);
        void RemoveRange(IEnumerable<TEntity> entities);

        void Update(TEntity old, TEntity newentity);




    }
}

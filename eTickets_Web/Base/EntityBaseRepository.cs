using eTickets_Web.Data;
using System.Linq.Expressions;

namespace eTickets_Web.Base
{
    // Genel CRUD metotlarını buraya toplayacağız
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        public EntityBaseRepository(AppDbContext context)
        {
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}

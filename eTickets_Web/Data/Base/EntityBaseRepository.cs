using eTickets_Web.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets_Web.Data.Base
{
    // Genel CRUD metotlarını buraya toplayacağız
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            // Üzerine gelen T Type buradaki modelim
            _context.Set<T>().Add(entity); // Hangi model için o an işlem yapacağını öğrenebilmesi ve işlemini yapabilmesi için 

            _context.SaveChanges(); // Db tarafına gönderim için

        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            EntityEntry entityEntry = _context.Entry<T>(entity);

            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted; // Kaydımı siliyor

            _context.SaveChanges();

        }

        public IEnumerable<T> GetAll()
        {
            var result = _context.Set<T>().ToList();

            return result;
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

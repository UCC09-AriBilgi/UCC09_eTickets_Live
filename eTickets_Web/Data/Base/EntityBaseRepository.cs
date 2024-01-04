using eTickets_Web.Data;
using Microsoft.EntityFrameworkCore;
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

        // Hepsi için (Actor,Cinema,Movie,Producer)
        // Bu metodun istediği tek şey model - T(Actor,Cinema,Producer
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

        // üzerine gelen T tipine (data) göre ilgili modelden verileri çeker.
        public IEnumerable<T> GetAll()
        {
            var result = _context.Set<T>().ToList(); // T üzerinden gelen modele göre oraya konumlanıp içeriği bir listeye döker.

            return result;
        }

        // Polymorphism -- Parametreli olarak listeleme
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            // Burası da herhangi bir parametreli şekilde VT tarafından listeleme yapılmak istendiğinde kullanılacak metot.
            IQueryable<T> query = _context.Set<T>();

            // buraya gelen parametrelere göre sorgu dinamik şekilde oluşturuluyor.
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));

            return query.ToList();
            
        }

        // üzerine gelen id parametresine göre şu an bilinmiyor çağıran servis hangi servisse T type o tablo olacak. ve o tablodan id ye göre sorgulama yapacak...
        public T GetById(int id) => _context.Set<T>().FirstOrDefault(n => n.Id == id);

        // üzerine gelen id ve model(T) parametrelerine göre güncelleme işlemi yapar.
        public void Update(int id, T entity)
        {
            EntityEntry entityEntry=_context.Entry<T>(entity); // buraya gelen T ye göre
            entityEntry.State=EntityState.Modified;
            _context.SaveChanges();

        }
    }
}

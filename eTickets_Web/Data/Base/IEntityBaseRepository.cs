using System.Linq.Expressions;

namespace eTickets_Web.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        // Ortak metotlar

        // Tüm kayıtları listeleme, çıkış tipi T ve bir liste yapısında(ENumerable)
        IEnumerable<T> GetAll();

        // Tüm kayıtları listeleme, ama parametreli yapı
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        // Sadece tek bir kayıt getirme
        T GetById(int id);

        // Kayıt ekleme
        void Add(T entity);

        // Kayıt güncelleme
        void Update(int id, T entity);

        // Kayıt silme..İlgili Modelden bunu çağıracağım için T yapısı kullanmadık
        void Delete(int id);


    }
}

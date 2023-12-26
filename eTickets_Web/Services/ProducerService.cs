using eTickets_Web.Base;
using eTickets_Web.Data;
using eTickets_Web.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context)
        {
                
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

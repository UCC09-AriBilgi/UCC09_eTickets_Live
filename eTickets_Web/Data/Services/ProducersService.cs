using eTickets_Web.Data;
using eTickets_Web.Data.Base;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Data.Services
{
    public class ProducersService : EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {

        }

    }
}

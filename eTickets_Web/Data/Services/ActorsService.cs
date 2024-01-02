using eTickets_Web.Data;
using eTickets_Web.Data.Base;
using eTickets_Web.Data.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Data.Services
{
    public class ActorsService : EntityBaseRepository<Actor>, IActorsService
    {
        // Dependency Injection
        public ActorsService(AppDbContext context) : base(context)
        {

        }


    }
}

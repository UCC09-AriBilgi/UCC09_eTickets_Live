using eTickets_Web.Base;
using eTickets_Web.Data;
using eTickets_Web.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Services
{
    public class CinemaService : EntityBaseRepository<Cinema>,ICinemaService
    {
        public CinemaService(AppDbContext context) : base(context)
        {
                
        }
    }
}

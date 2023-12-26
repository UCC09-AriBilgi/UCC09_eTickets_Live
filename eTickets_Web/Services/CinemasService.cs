using eTickets_Web.Base;
using eTickets_Web.Data;
using eTickets_Web.Interfaces;
using eTickets_Web.Models;

namespace eTickets_Web.Services
{
    public class CinemasService : EntityBaseRepository<Cinema>,ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
                
        }
    }
}

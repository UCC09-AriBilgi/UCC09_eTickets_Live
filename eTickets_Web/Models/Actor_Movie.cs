namespace eTickets_Web.Models
{
    // Hangi aktor hangi filmde oynuyor türünden bilgileri tutacak.(db tarafındaki junction table mantığında

    public class Actor_Movie
    {
        public int MovieId { get; set; }
        public Movie? Movie { get; set; } // Movie modelinden gelecek olan bilgi için

        public int ActorId {  get; set; }
        public Actor? Actor { get; set; } // Actor modelinden gelecek olan bilgi için

    }
}

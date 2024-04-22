
namespace Final_Kim.Models
{
    public class EFEntertainementRepository : IEntertainmentRepository
    {
        private EntertainmentAgencyExampleContext _context;

        public EFEntertainementRepository(EntertainmentAgencyExampleContext temp)
        {
            _context = temp;
        }

        public List<Entertainer> entertainers => _context.Entertainers.ToList();
        public IQueryable<Entertainer> Entertainers => _context.Entertainers;

        public void AddEntertainer(Entertainer entertainer)
        {
            // To add an entertainer
            _context.Add(entertainer);
            _context.SaveChanges();
        }

        public void EditEntertainer(Entertainer ent)
        {
            // to edit an entertainer's info
            _context.Update(ent);
            _context.SaveChanges();
        }

        public void DeleteEntertainer(Entertainer ent)
        {
            // to delete and entertainer
            _context.Entertainers.Remove(ent);
            _context.SaveChanges();
        }
    }
}

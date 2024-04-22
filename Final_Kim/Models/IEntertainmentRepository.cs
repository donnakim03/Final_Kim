namespace Final_Kim.Models
{
    public interface IEntertainmentRepository
    {
        public List<Entertainer> entertainers { get; }
        public IQueryable<Entertainer> Entertainers { get; }

        public void AddEntertainer(Entertainer entertainer);
        public void EditEntertainer(Entertainer ent);

        public void DeleteEntertainer(Entertainer ent);
    }
}

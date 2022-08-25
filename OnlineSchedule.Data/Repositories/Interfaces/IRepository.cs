namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface IRepository<Tid, T>
    {
        void Add(T item);
        void Remove(T item);
        void RemoveAt(Tid id);
        T Get(Tid id);
    }
}

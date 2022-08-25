using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface IHistoryRepository<T> : IRepository<Guid, T> where T : HistoryItem
    {
        List<T> GetList(int page);
    }
}

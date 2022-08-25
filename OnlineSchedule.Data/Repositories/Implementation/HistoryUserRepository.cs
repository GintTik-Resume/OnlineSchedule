using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class HistoryUserRepository : IHistoryUserRepository
    {
        private const int PageSize = 10;
        private readonly ScheduleContext _context;

        public HistoryUserRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(HistoryUserItem item)
        {
            _context.HistoryUser.Add(item);
            _context.SaveChanges();
        }

        public HistoryUserItem Get(Guid id)
        {
            return _context.HistoryUser.FirstOrDefault(x => x.Id == id);
        }

        public List<HistoryUserItem> GetList(int page)
        {
            return _context.HistoryUser?.SkipLast((page - 1) * PageSize)?.TakeLast(page * PageSize)?.ToList();
        }

        public void Remove(HistoryUserItem item)
        {
            _context.HistoryUser.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAt(Guid id)
        {
            var item = Get(id);

            if(item != null)
                Remove(item);
        }
    }
}

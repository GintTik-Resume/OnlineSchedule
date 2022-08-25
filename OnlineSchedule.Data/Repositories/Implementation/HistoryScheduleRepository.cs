using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class HistoryScheduleRepository : IHistoryScheduleRepository
    {
        private const int PageSize = 10;
        private readonly ScheduleContext _context;

        public HistoryScheduleRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(HistoryScheduleItem item)
        {
            _context.HistorySchedule.Add(item);
            _context.SaveChanges();
        }

        public HistoryScheduleItem Get(Guid id)
        {
            return _context.HistorySchedule.FirstOrDefault(x => x.Id == id);
        }

        public List<HistoryScheduleItem> GetList(int page)
        {
            return _context.HistorySchedule?.SkipLast((page - 1) * PageSize)?.TakeLast(page * PageSize)?.ToList();
        }

        public void Remove(HistoryScheduleItem item)
        {
            _context.HistorySchedule.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAt(Guid id)
        {
            var item = Get(id);

            if (item != null)
                Remove(item);
        }
    }
}

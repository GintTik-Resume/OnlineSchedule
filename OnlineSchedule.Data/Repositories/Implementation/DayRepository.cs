using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class DayRepository : IDayRepository
    {
        private readonly ScheduleContext _context;

        public DayRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(Day item)
        {
            _context.Days.Add(item);
            _context.SaveChanges();
        }

        public Day Get(Guid id)
        {
            return _context.Days.FirstOrDefault(o => o.Id == id);
        }

        public List<Day> GetBySchedule(Guid scheduleId)
        {
            return _context.Days.Where(o => o.ScheduleId == scheduleId).ToList();
        }

        public void Remove(Day item)
        {
            _context.Days.Remove(item);
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

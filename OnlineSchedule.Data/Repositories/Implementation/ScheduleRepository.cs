using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ScheduleContext _context;

        public ScheduleRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(Schedule item)
        {
            _context.Schedules.Add(item);
            _context.SaveChanges();
        }

        public Schedule Get(Guid id)
        {
            return _context.Schedules.FirstOrDefault(o => o.Id == id);
        }

        public List<Schedule> GetByUserId(string userId)
        {
            return _context.Schedules.Where(o => o.UserId == userId).ToList();
        }

        public void Remove(Schedule item)
        {
            _context.Schedules.Remove(item);
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

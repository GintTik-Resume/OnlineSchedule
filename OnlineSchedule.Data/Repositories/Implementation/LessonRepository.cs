using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ScheduleContext _context;

        public LessonRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(Lesson item)
        {
            _context.Lessons.Add(item);
            _context.SaveChanges();
        }

        public Lesson Get(Guid id)
        {
            return _context.Lessons.FirstOrDefault(o => o.Id == id);
        }

        public List<Lesson> GetByDay(Guid dayId)
        {
            return _context.Lessons.Where(o => o.DayId == dayId).ToList();
        }

        public void Remove(Lesson item)
        {
            _context.Lessons.Remove(item);
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

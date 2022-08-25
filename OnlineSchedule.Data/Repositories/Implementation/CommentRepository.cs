using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ScheduleContext _context;

        public CommentRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(Comment item)
        {
            _context.Comments.Add(item);
            _context.SaveChanges();
        }

        public Comment Get(Guid id)
        {
            return _context.Comments.FirstOrDefault(c => c.Id == id);
        }

        public List<Comment> GetBySchedule(Guid scheduleId)
        {
            return _context.Comments.Where(o => o.ScheduleId == scheduleId).ToList();
        }

        public void Remove(Comment item)
        {
            _context.Comments.Remove(item);
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

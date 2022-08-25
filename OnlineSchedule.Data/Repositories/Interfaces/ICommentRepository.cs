using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface ICommentRepository : IRepository<Guid, Comment>
    {
        List<Comment> GetBySchedule(Guid scheduleId);
    }
}

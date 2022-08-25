using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface ILessonRepository : IRepository<Guid, Lesson>
    {
        List<Lesson> GetByDay(Guid dayId);
    }
}

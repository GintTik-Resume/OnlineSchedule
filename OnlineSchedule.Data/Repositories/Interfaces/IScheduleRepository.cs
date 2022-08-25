using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface IScheduleRepository : IRepository<Guid, Schedule>
    {
        List<Schedule> GetByUser(string userId);
    }
}

using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface IScheduleRepository : IRepository<Guid, Schedule>
    {
        List<Schedule> GetByUserId(string userId);
    }
}

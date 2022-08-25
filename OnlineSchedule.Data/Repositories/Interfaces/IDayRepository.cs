using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface IDayRepository : IRepository<Guid, Day>
    {
        List<Day> GetBySchedule(Guid scheduleId);
    }
}

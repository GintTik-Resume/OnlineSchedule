using OnlineSchedule.Data.Entities;

namespace OnlineSchedule.Data.Repositories.Interfaces
{
    public interface ITypeOfActionRepository : IRepository<Guid, TypeOfAction>
    {
        TypeOfAction GetByName(string name);
    }
}

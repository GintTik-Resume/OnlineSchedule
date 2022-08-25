using OnlineSchedule.Data.Contexts;
using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.Data.Repositories.Implementation
{
    public class TypeOfActionRepository : ITypeOfActionRepository
    {
        private readonly ScheduleContext _context;

        public TypeOfActionRepository(ScheduleContext context)
        {
            _context = context;
        }

        public void Add(TypeOfAction item)
        {
            _context.TypeOfActions.Add(item);
            _context.SaveChanges();
        }

        public TypeOfAction Get(Guid id)
        {
            return _context.TypeOfActions.FirstOrDefault(o => o.Id == id);
        }

        public TypeOfAction GetByName(string name)
        {
            return _context.TypeOfActions.FirstOrDefault(o => o.Name == name);
        }

        public void Remove(TypeOfAction item)
        {
            if(item == null)
                throw new ArgumentNullException("item");

            _context.TypeOfActions.Remove(item);
            _context.SaveChanges();
        }

        public void RemoveAt(Guid id)
        {
            var item = Get(id);
            if (item != null)
                Remove(item);
        }
    }
}

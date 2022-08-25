using OnlineSchedule.Data.Entities;
using OnlineSchedule.Data.Repositories.Interfaces;

namespace OnlineSchedule.BusinessLogic.History
{
    public class HistoryLogger
    {
        private readonly IHistoryUserRepository _historyUser;
        private readonly IHistoryScheduleRepository _historySchedule;

        private readonly ITypeOfActionRepository _typeOfActionRepository;

        public HistoryLogger(IHistoryUserRepository historyUser, IHistoryScheduleRepository historySchedule, ITypeOfActionRepository typeOfActionRepository)
        {
            _historyUser = historyUser;
            _historySchedule = historySchedule;
            _typeOfActionRepository = typeOfActionRepository;
        }

        public void LogUser(string performerId, string userId, string action)
        {
            var item = new HistoryUserItem()
            {
                UserId = userId,
                PerformerId = performerId,
                TypeOfActionId = _typeOfActionRepository.GetByName(action).Id,
            };

            _historyUser.Add(item);
        }

        public void LogSchedule(string performerId, string scheduleId, string action)
        {
            var item = new HistoryScheduleItem()
            {
                ScheduleId = scheduleId,
                PerformerId = performerId,
                TypeOfActionId = _typeOfActionRepository.GetByName(action).Id,
            };

            _historySchedule.Add(item);
        }
    }
}

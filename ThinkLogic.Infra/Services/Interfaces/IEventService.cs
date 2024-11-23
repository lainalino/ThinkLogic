
using ThinkLogic.Domain.Entities;

namespace ThinkLogic.Infra.Services.Interfaces
{
    public interface IEventService
    {
        public Task<Event> GetEventById(Guid id);
        public Task AddEvent(Event evt);
        public Task<IEnumerable<Event>> GetEventsByDate(DateTime date);
        public Task UpdateEvent(Event evt);
        public Task<IEnumerable<Event>> GetEvents();
    }
}

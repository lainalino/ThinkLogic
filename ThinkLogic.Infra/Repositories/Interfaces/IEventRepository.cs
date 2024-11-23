
using ThinkLogic.Domain.Entities;

namespace ThinkLogic.Infra.Repositories.Interfaces
{
    public interface IEventRepository
    {
        public Task<Event> GetEventById (Guid id);
        public Task AddEventAsync(Event evt);
        public Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date);
        public Task UpdateEventAsync(Event evt);
        public Task<IEnumerable<Event>> GetEvents();
    }
}

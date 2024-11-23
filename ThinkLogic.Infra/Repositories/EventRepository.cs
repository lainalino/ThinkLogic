using Microsoft.EntityFrameworkCore;
using ThinkLogic.Data.Context;
using ThinkLogic.Domain.Entities;
using ThinkLogic.Infra.Repositories.Interfaces;

namespace ThinkLogic.Infra.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;

        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Event> GetEventById(Guid id)
        {
            return await _context.Events.FindAsync(id);
        }

        public async Task AddEventAsync(Event evt)
        {
            await _context.Events.AddAsync(evt);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _context.Events
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetEventsByDateAsync(DateTime date)
        {
            return await _context.Events
                .Where(e => e.StartDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task UpdateEventAsync(Event evt)
        {
            var local = _context.Events.Local.FirstOrDefault(e => e.Id == evt.Id);
            if (local != null)
            {
                // Desanexar a entidade existente se já estiver sendo rastreada
                _context.Entry(local).State = EntityState.Detached;
            }

            _context.Events.Update(evt);
            await _context.SaveChangesAsync();
        }

    }
}

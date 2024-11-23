using ThinkLogic.Domain.Entities;
using ThinkLogic.Infra.Repositories.Interfaces;
using ThinkLogic.Infra.Services.Interfaces;

namespace ThinkLogic.Infra.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Retrieves an event by its unique identifier.
        /// Throws a KeyNotFoundException if the event is not found.
        /// </summary>
        /// <param name="id">The unique identifier of the event to retrieve.</param>
        /// <returns>The event matching the provided identifier.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if no event is found with the specified ID.</exception>

        public async Task<Event> GetEventById(Guid id)
        {
            var evt = await _eventRepository.GetEventById(id);

            if (evt == null)
            {
                throw new KeyNotFoundException($"Event with ID {id} not found.");
            }
            return evt;
        }

        /// <summary>
        /// Adds a new event to the repository after validating that the start date is earlier than the end date.
        /// </summary>
        /// <param name="evt">The event object containing the details of the event to be added.</param>
        /// <exception cref="InvalidOperationException">Thrown if the start date is not earlier than the end date.</exception>
        /// <returns>A task that represents the asynchronous operation.</returns>

        public async Task AddEvent(Event evt)
        {
            if (evt.StartDate >= evt.EndDate)
            {
                throw new InvalidOperationException("Start Date must be earlier than End Date.");
            }

            await _eventRepository.AddEventAsync(evt);
        }

        /// <summary>
        /// Retrieves a list of events for the specified date from the repository.
        /// </summary>
        /// <param name="date">The date for which the events need to be fetched.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of events occurring on the specified date.</returns>

        public async Task<IEnumerable<Event>> GetEventsByDate(DateTime date)
        {
            return await _eventRepository.GetEventsByDateAsync(date);
        }

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="eventModel">The event model containing the updated event data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        /// 
        public async Task UpdateEvent(Event eventModel)
        {
            var existingEvent = await _eventRepository.GetEventById(eventModel.Id);
            if (existingEvent == null)
            {
                throw new KeyNotFoundException($"Event with ID {eventModel.Id} not found.");
            }


            await _eventRepository.UpdateEventAsync(eventModel);
        }

        /// <summary>
        /// Retrieves all events from the repository.
        /// This method calls the repository to fetch a list of events asynchronously.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="Event"/> objects representing all events in the repository.
        /// </returns>
        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await _eventRepository.GetEvents();
        }
    }
}

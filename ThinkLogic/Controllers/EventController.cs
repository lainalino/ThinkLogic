using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ThinkLogic.Domain.Entities;
using ThinkLogic.Infra.Services.Interfaces;

namespace ThinkLogic.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService _eventService;

        // Constructor that injects the event service into the controller
        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        /// <summary>
        /// Retrieves a list of events and passes them to the Index view for display.
        /// </summary>
        /// <returns>An IActionResult representing the Index view with the list of events.</returns>

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetEvents();
            return View(events);  // Passes the events to the Index view
        }

        // Create Action (GET): Displays the create event form
        public IActionResult Create()
        {
            return View(new Event());  // Render the Create view
        }

        /// <summary>
        /// Handles the submission of the create event form to add a new event.
        /// </summary>
        /// <param name="eventModel">The event model containing the new event data from the form.</param>
        /// <returns>Redirects to the event index page if successful or displays validation errors if any occur.</returns>

        [HttpPost]
        public async Task<IActionResult> Create(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _eventService.AddEvent(eventModel);  // Add event via service
                    return RedirectToAction("Index");  // Redirect back to the event list (Index)
                }
                catch (InvalidOperationException ex)
                {
                    // Add the error message to ModelState
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "An error occurred while saving the event. Please try again.");
                }
            }
            return View(eventModel);  // Return the same view with validation errors if the model is invalid
        }

        /// <summary>
        /// Displays the edit form for a specific event.
        /// </summary>
        /// <param name="id">The ID of the event to edit.</param>
        /// <returns>An Edit view with the event data.</returns>
        public async Task<IActionResult> Edit(Guid id)
        {
            var evt = await _eventService.GetEventById(id);
            if (evt == null)
            {
                return NotFound();  // If event not found, return 404
            }
            return View(evt);  // Pass the event to the Edit view
        }

        /// <summary>
        /// Handles the submission of the edit form to update an event.
        /// </summary>
        /// <param name="id">The ID of the event being edited.</param>
        /// <param name="eventModel">The event model with updated data from the form.</param>
        /// <returns>Redirects to the event index page or displays the form with errors.</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Event eventModel)
        {
            if (id != eventModel.Id)
            {
                return BadRequest();  // If the IDs don't match, return an error
            }

            try
            {
                if (ModelState.IsValid)
                {
                    await _eventService.UpdateEvent(eventModel); // Update the event in the database
                    return RedirectToAction("Index");  // Redirect back to the event list after successful update
                }
            }
            catch (Exception)
            {
                // Handle exception (e.g., event not found or database issues)
                return View(eventModel);
            }

            return View(eventModel);  // If validation fails, return the view with validation errors
        }

    }
}

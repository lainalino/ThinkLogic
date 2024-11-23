
using System.ComponentModel.DataAnnotations;

namespace ThinkLogic.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(200)]
        public string Location { get; set; }

        public string Description { get; set; }
    }
}

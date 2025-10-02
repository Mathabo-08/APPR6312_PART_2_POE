using System.ComponentModel.DataAnnotations;

namespace GiftOfTheGivers.WebApp.DTOs
{
    public class VolunteerProfileDto
    {
        [Required(ErrorMessage = "Please provide an emergency contact name.")]
        [StringLength(100)]
        public string EmergencyContactName { get; set; }

        [Required(ErrorMessage = "Please provide an emergency contact number.")]
        [Phone]
        public string EmergencyContactPhone { get; set; }

        public List<string> Skills { get; set; } = new();
        public List<string> Availability { get; set; } = new();
    }
}
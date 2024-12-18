using PatientAppointmentApp.Models;

namespace PatientAppointmentApp.Models
{
    public class ApplicationUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}

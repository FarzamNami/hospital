using System.ComponentModel.DataAnnotations;

namespace PatientAppointmentApp.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } // Legal name

        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } // Contact number

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Unique email

        [Required]
        public string PasswordHash { get; set; } // Secure hashed password

        [StringLength(500)]
        public string MedicalHistory { get; set; } // Optional medical history

        // Navigation property for appointments
        public ICollection<Appointment> Appointments { get; set; }
    }
}

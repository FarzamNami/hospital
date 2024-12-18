using System.ComponentModel.DataAnnotations;

namespace PatientAppointmentApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } // Full name of the doctor

        [Required]
        [StringLength(50)]
        public string Specialty { get; set; } // Medical specialty (e.g., Dentist)

        [Required]
        public string Schedule { get; set; } // Serialized JSON schedule data

        [Required]
        public int AppointmentLength { get; set; } // Appointment duration in minutes

        // Navigation property for appointments
        public ICollection<Appointment> Appointments { get; set; }
    }
}

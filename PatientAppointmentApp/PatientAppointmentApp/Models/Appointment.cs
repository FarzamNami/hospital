using PatientAppointmentApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientAppointmentApp.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; } // Primary Key

        [Required]
        public DateTime AppointmentDate { get; set; } // Date of appointment

        [Required]
        public string Timeslot { get; set; } // Timeslot (start-finish)

        [Required]
        public string Status { get; set; } // Status (Pending, Approved, Booked)

        // Foreign keys and navigation properties
        [Required]
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

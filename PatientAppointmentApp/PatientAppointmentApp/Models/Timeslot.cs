using PatientAppointmentApp.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientAppointmentApp.Models
{
    public class Timeslot
    {
        [Key]
        public int TimeslotId { get; set; } // Primary Key

        [Required]
        public DateTime SlotDate { get; set; } // Date of the slot

        [Required]
        public TimeSpan StartTime { get; set; } // Slot start time

        [Required]
        public TimeSpan EndTime { get; set; } // Slot end time

        [Required]
        public string Status { get; set; } // Available, Pending, Booked

        // Foreign Key and Navigation property
        [Required]
        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}

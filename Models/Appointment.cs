namespace ProiectMedii.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        // Foreign keys
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

        // Navigation properties
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}

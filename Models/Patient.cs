namespace ProiectMedii.Models
{
    // Models/Patient.cs
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Other patient-related properties...

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public PatientFile PatientFile { get; set; }
    }

}

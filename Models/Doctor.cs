namespace ProiectMedii.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }



        // Other doctor-related properties...

        public ICollection<Appointment> Appointments { get; set; }
    }
}

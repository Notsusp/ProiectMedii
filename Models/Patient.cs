namespace ProiectMedii.Models
{
    // Models/Patient.cs
    public class Patient
    {
        public enum GenderType
        {
            Male,
            Female
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string IdCard { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string InsuranceProvider { get; set; }

        public Patient()
        {

        }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public PatientFile PatientFile { get; set; }
    }

}

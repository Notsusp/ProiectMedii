using Microsoft.CodeAnalysis.Scripting;
using ProiectMedii.Pages.Doctors;
using BCrypt.Net;


namespace ProiectMedii.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Specialization Specialization { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string LicenseNumber { get; set; }
        public string PhoneNumber { get; set; }
        public Doctor(string password)
        {
            HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        }
        public Doctor(string name, string licenseNumber, string email, string phoneNumber, string hashedPassword)
        {
            Name = name;
            LicenseNumber = licenseNumber;
            Email = email;
            PhoneNumber = phoneNumber;
            HashedPassword = hashedPassword;
        }
        public Doctor() {

        }


        // Other doctor-related properties...

        public ICollection<Appointment> Appointments { get; set; }
        public bool VerifyPassword(string enteredPassword)
        {
            // Use BCrypt's verification method to compare hashedPassword with enteredPassword
            return BCrypt.Net.BCrypt.Verify(enteredPassword, HashedPassword);
        }
    }
}

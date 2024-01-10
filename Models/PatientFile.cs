namespace ProiectMedii.Models
{
    public class PatientFile
    {
        public int Id { get; set; }
        public string Conditions { get; set; }
        public string PastVisitsSummary { get; set; }

        // Foreign key
        public int PatientId { get; set; }

        // Navigation property
        public Patient Patient { get; set; }
    }
}

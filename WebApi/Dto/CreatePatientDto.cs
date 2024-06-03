namespace WebApi.Dto
{
    public class CreatePatientDto
    {
        public Int32 Id { get; set; }
        public PatientName Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String? Gender { get; set; }
        public String? Active { get; set; }
    }

    public class PatientName
    {

    }
}

namespace Db.Models
{
    public class Patient
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public String? Gender { get; set; }
        public String? Active { get; set; }
    }
}

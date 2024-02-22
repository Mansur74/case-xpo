namespace CaseAPI.Models
{
    public class LicenseDto
    {
        public int Oid { get; set; }
        public string Name { get; set; }
        public DocumentDto? Document { get; set; }
    }
}

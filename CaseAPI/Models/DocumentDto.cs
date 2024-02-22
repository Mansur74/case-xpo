using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using System.ComponentModel;
using License = CaseAPI.Models.caseproj.License;

namespace CaseAPI.Models
{
    public class DocumentDto
    {
        public int Oid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ICollection<LicenseDto> Licenses { get; set; } = new List<LicenseDto>();
    }
}

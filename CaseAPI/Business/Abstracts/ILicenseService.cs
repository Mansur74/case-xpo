using CaseAPI.Models;

namespace CaseAPI.Business.Abstracts
{
    public interface ILicenseService
    {
        public void Create(LicenseDto licenseDto, int documentId);
        public void Delete(int licenseId);
        public void Update(LicenseDto licenseDto, int licenseId);
        public LicenseDto GetById(int licenseId);
        public ICollection<LicenseDto> GetAll();
    }
}

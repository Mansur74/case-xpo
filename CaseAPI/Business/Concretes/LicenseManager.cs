using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using Microsoft.Extensions.Logging;
using Document = CaseAPI.Models.caseproj.Document;

namespace CaseAPI.Business.Concretes
{
    public class LicenseManager : ILicenseService
    {
        private readonly ILicenseDal _licenseDal;
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        public LicenseManager(ILicenseDal licenseDal, IDocumentDal documentDal, IMapper mapper)
        {
            _licenseDal = licenseDal;
            _documentDal = documentDal;
            _mapper = mapper;
        }
        public void Create(LicenseDto licenseDto, int documentId)
        {
            Document document = _documentDal.Get((d) => d.Oid == documentId);
            if (document == null)
                throw new Exception("Document does not exist");

            License license = _licenseDal.CreateObject();
            license = _mapper.Map(licenseDto, license);
;           license.Document = document;
            _licenseDal.Save();
        }

        public void Delete(int licenseId)
        {
            License license = _licenseDal.Get((l) => l.Oid == licenseId);
            if (license == null)
                throw new Exception("License does not exist");

            _licenseDal.Delete(license);
        }

        public ICollection<LicenseDto> GetAll()
        {
            ICollection<License> licenses = _licenseDal.GetAll();
            ICollection<LicenseDto> result = _mapper.Map<ICollection<LicenseDto>>(licenses);
            return result;
        }

        public LicenseDto GetById(int licenseId)
        {
            License license = _licenseDal.Get((l) => l.Oid == licenseId);
            if (license == null)
                throw new Exception("License does not exist");

            return _mapper.Map<LicenseDto>(license);
        }

        public void Update(LicenseDto licenseDto, int licenseId)
        {
            License license = _licenseDal.Get((l) => l.Oid == licenseId);
            if (license == null)
                throw new Exception("License does not exist");

            license.Name = licenseDto.Name;
            _licenseDal.Save();
        }
    }
}

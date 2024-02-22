using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using System.Reflection.Metadata;
using Document = CaseAPI.Models.caseproj.Document;

namespace CaseAPI.Business.Concretes
{
    public class LicenseManager : ILicenseService
    {
        private readonly ILicenseDal _licenseDal;
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;
        public LicenseManager(ILicenseDal licenseDal, IDocumentDal documentDal, IMapper mapper , UnitOfWork uow)
        {
            _licenseDal = licenseDal;
            _documentDal = documentDal;
            _mapper = mapper;
            _uow = uow;
        }
        public void Create(LicenseDto licenseDto, int documentId)
        {
            Document document = _documentDal.Get((d) => d.Oid == documentId);
            License license = new License(_uow);
            license = _mapper.Map(licenseDto, license);
;           license.Document = document;
            _licenseDal.Add(license);
        }

        public void Delete(int licenseId)
        {
            _licenseDal.Delete((d) => d.Oid == licenseId);
        }

        public ICollection<LicenseDto> GetAll()
        {
            ICollection<License> licenses = _licenseDal.GetAll();
            ICollection<LicenseDto> result = _mapper.Map<ICollection<LicenseDto>>(licenses);
            return result;
        }
    }
}

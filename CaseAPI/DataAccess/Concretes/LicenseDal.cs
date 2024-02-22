using CaseAPI.Core.DataAccess;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;

namespace CaseAPI.DataAccess.Concretes
{
    public class LicenseDal : Repository<License>, ILicenseDal
    {
        public LicenseDal(UnitOfWork uow) : base(uow)
        {
        }
    }
}

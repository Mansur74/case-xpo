using CaseAPI.Core.DataAccess;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;

namespace CaseAPI.DataAccess.Concretes
{
    public class DocumentDal : Repository<Document>, IDocumentDal
    {
        public DocumentDal(UnitOfWork uow) : base(uow)
        {

        }
    }
}

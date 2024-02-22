using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;

namespace CaseAPI.Business.Concretes
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        private readonly UnitOfWork _uow;
        public DocumentManager(IDocumentDal documentDal, IMapper mapper, UnitOfWork uow) 
        {
            _documentDal = documentDal;
            _mapper = mapper;
            _uow = uow;
        }
        public void Create(DocumentDto documentDto)
        {
            Document document = new Document(_uow);
            document = _mapper.Map(documentDto, document);
            _documentDal.Add(document);
        }

        public ICollection<DocumentDto> GetAll()
        {
            ICollection<Document> documents = _documentDal.GetAll();
            ICollection<DocumentDto> result = _mapper.Map<ICollection<DocumentDto>>(documents);
            return result;
        }
    }
}

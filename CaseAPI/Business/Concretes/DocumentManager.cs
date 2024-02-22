using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;

namespace CaseAPI.Business.Concretes
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        public DocumentManager(IDocumentDal documentDal, IMapper mapper ) 
        {
            _documentDal = documentDal;
            _mapper = mapper;
        }
        public void Create(DocumentDto documentDto)
        {
            Document document = _mapper.Map<Document>(documentDto);
            _documentDal.Create(document);
        }

        public ICollection<DocumentDto> GetAll()
        {
            ICollection<Document> documents = _documentDal.GetAll();
            ICollection<DocumentDto> result = _mapper.Map<ICollection<DocumentDto>>(documents);
            return result;
        }
    }
}

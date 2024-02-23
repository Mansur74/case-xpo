using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.DataAccess.Concretes;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using System.ComponentModel;
using System.Reflection.Metadata;
using Document = CaseAPI.Models.caseproj.Document;

namespace CaseAPI.Business.Concretes
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        public DocumentManager(IDocumentDal documentDal, IMapper mapper) 
        {
            _documentDal = documentDal;
            _mapper = mapper;
        }
        public void Create(DocumentDto documentDto)
        {
            Document document = _documentDal.CreateObject();
            document = _mapper.Map(documentDto, document);
            _documentDal.Save();
        }

        public void Delete(int documentId)
        {
            Document document = _documentDal.Get((d) => d.Oid == documentId);
            if (document == null)
                throw new Exception("Document does not exist");

            _documentDal.Delete(document);
        }

        public ICollection<DocumentDto> GetAll()
        {
            ICollection<Document> documents = _documentDal.GetAll();
            ICollection<DocumentDto> result = _mapper.Map<ICollection<DocumentDto>>(documents);
            return result;
        }

        public DocumentDto GetById(int documentId)
        {
            Document document = _documentDal.Get((l) => l.Oid == documentId);
            if (document == null)
                throw new Exception("Document does not exist");

            return _mapper.Map<DocumentDto>(document);
        }

        public void Update(DocumentDto documentDto, int documentId)
        {
            Document document = _documentDal.Get((l) => l.Oid == documentId);
            if (document == null)
                throw new Exception("Document does not exist");

            document.Name = documentDto.Name;
            document.Url = documentDto.Url;
            _documentDal.Save();
        }
    }
}

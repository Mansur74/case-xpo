using CaseAPI.Models;
using CaseAPI.Models.caseproj;

namespace CaseAPI.Business.Abstracts
{
    public interface IDocumentService
    {
        public ICollection<DocumentDto> GetAll();
        public bool Create(DocumentDto documentDto);
        public bool Delete(int documentId);
        public bool Update(DocumentDto documentDto, int documentId);
        public DocumentDto GetById(int documentId);

    }
}

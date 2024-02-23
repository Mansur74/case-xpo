using CaseAPI.Models;
using CaseAPI.Models.caseproj;

namespace CaseAPI.Business.Abstracts
{
    public interface IDocumentService
    {
        public ICollection<DocumentDto> GetAll();
        public void Create(DocumentDto documentDto);
        public void Delete(int documentId);
        public void Update(DocumentDto documentDto, int documentId);
        public DocumentDto GetById(int documentId);

    }
}

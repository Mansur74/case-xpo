using CaseAPI.Models;
using CaseAPI.Models.caseproj;

namespace CaseAPI.Business.Abstracts
{
    public interface IDocumentService
    {
        public ICollection<DocumentDto> GetAll();
        public void Create(DocumentDto documentDto);
     
    }
}

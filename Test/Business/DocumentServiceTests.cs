using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.Business.Concretes;
using CaseAPI.Core.Utilities;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.DataAccess.Concretes;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using FakeItEasy;
using System.Linq.Expressions;


namespace CaseAPI.Tests.Business
{
    public class DocumentServiceTests
    {
        private readonly IDocumentService _documentService;
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        public DocumentServiceTests()
        {
            _documentDal = A.Fake<IDocumentDal>();
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            _mapper = configuration.CreateMapper();
            _documentService = new DocumentManager(_documentDal, _mapper);
        }   

        [Fact]
        public void DocumentService_GetAll_ICollection()
        {
            ICollection<Document> fDocuments = A.Fake<ICollection<Document>>();
            A.CallTo(() => _documentDal.GetAll()).Returns(fDocuments);
            ICollection<DocumentDto> result = _documentService.GetAll();
            Assert.NotNull(result);  
        }

        [Fact]
        public void DocumentService_GetById_DocumentDto()
        {
            Document fDocument = A.Fake<Document>();
            A.CallTo(() => _documentDal.Get(A<Expression<Func<Document, bool>>>._)).Returns(fDocument);
            DocumentDto result = _documentService.GetById(5);
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentService_Delete_Bool()
        {
            Document fDocument = A.Fake<Document>();
            A.CallTo(() => _documentDal.Delete(fDocument));
            bool result = _documentService.Delete(5);
            Assert.True(result);
            
        }

        [Fact]
        public void DocumentService_Create_Bool()
        {
            Document fDocument = A.Fake<Document>();
            DocumentDto fDocumentDto = A.Fake<DocumentDto>();
            A.CallTo(() => _documentDal.CreateObject()).Returns(fDocument);
            bool result = _documentService.Create(fDocumentDto);
            Assert.True(result);

        }

        [Fact]
        public void DocumentService_Update_Bool()
        {
            Document fDocument = A.Fake<Document>();
            DocumentDto fDocumentDto = A.Fake<DocumentDto>();
            A.CallTo(() => _documentDal.Get(A<Expression<Func<Document, bool>>>._)).Returns(fDocument);
            bool result = _documentService.Update(fDocumentDto, 5);
            Assert.True(result);

        }
    }
}

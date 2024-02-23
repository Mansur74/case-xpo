using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.Business.Concretes;
using CaseAPI.Core.Utilities;
using CaseAPI.DataAccess.Abstracts;
using CaseAPI.DataAccess.Concretes;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using FakeItEasy;
using FluentAssertions;
using Test;

namespace CaseAPI.Tests.Business
{
    public class DocumentServiceTest
    {
        private readonly IDocumentService _documentService;
        private readonly IDocumentDal _documentDal;
        private readonly IMapper _mapper;
        public DocumentServiceTest()
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
        public void DocumentService_GetAll_ReturnDocumentDto()
        {
            ICollection<Document> fakeDocuments = A.Fake<ICollection<Document>>();
            A.CallTo(() => _documentDal.GetAll()).Returns(fakeDocuments);
            ICollection<DocumentDto> result = _documentService.GetAll();
            result.Should().NotBeNull();    
        }

        [Fact]
        public void DocumentService_Create_ReturnVoid()
        {
            Document fakeDocument = A.Fake<Document>();
            DocumentDto documentDto = A.Fake<DocumentDto>();
            A.CallTo(() => _documentDal.CreateObject()).Returns(fakeDocument);
            _documentService.Create(documentDto);
            A.CallTo(() => _documentDal.Save()).MustHaveHappenedOnceExactly();
        }
    }
}

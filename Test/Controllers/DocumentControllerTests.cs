using CaseAPI.Business.Abstracts;
using CaseAPI.Controllers;
using CaseAPI.Models;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Controllers
{
    public class DocumentControllerTests
    {
        private readonly DocumentController _controller;
        private readonly IDocumentService _documentService;
        public DocumentControllerTests() 
        {
            _documentService = A.Fake<IDocumentService>();
            _controller = new DocumentController(_documentService); 
        }

        [Fact]
        public void DocumentController_GetAll_IActionResult()
        {
            ICollection<DocumentDto> fDocuments = A.Fake<ICollection<DocumentDto>>(); 
            A.CallTo(() => _documentService.GetAll()).Returns(fDocuments);
            IActionResult result = _controller.GetAll();
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentController_GetById_IActionResult()
        {
            DocumentDto fDocument = A.Fake<DocumentDto>();
            A.CallTo(() => _documentService.GetById(A<int>._)).Returns(fDocument);
            IActionResult result = _controller.GetById(5);
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentController_Create_IActionResult()
        {
            DocumentDto fDocumentDto = A.Fake<DocumentDto>();
            A.CallTo(() => _documentService.Create(A<DocumentDto>._)).Returns(true);
            IActionResult result = _controller.Create(fDocumentDto);
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentController_Update_IActionResult()
        {
            DocumentDto fDocumentDto = A.Fake<DocumentDto>();
            A.CallTo(() => _documentService.Update(A<DocumentDto>._, A<int>._)).Returns(true);
            IActionResult result = _controller.Update(fDocumentDto, 5);
            Assert.NotNull(result);
        }

        [Fact]
        public void DocumentController_Delete_IActionResult()
        {
            A.CallTo(() => _documentService.Delete(A<int>._)).Returns(true);
            IActionResult result = _controller.Delete(5);
            Assert.NotNull(result);
        }
    }
}

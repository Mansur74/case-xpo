using AutoMapper;
using CaseAPI.Business.Abstracts;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Xpo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static DevExpress.Data.Helpers.ExpressiveSortInfo;

namespace CaseAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("documents")]
        public IActionResult GetAll()
        {

            ICollection<DocumentDto> result = _documentService.GetAll();
;           return Ok(result);

        }

        [HttpPost("document")]
        public IActionResult Post([FromBody] DocumentDto documentDto)
        {
            _documentService.Create(documentDto);
            return StatusCode(201, "Created Successfully");
        }

        [HttpDelete("document/{documentId}")]
        public IActionResult Delete(int documentId)
        {
            _documentService.Delete(documentId);
            return Ok("Deleted Successfully");
        }
    }
}

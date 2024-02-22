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
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;

        public DocumentController(UnitOfWork uow, IMapper mapper, IDocumentService documentService)
        {
            _uow = uow;
            _mapper = mapper;
            _documentService = documentService;
        }

        [HttpGet("document")]
        public IActionResult Get()
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
    }
}

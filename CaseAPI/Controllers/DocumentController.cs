﻿using CaseAPI.Business.Abstracts;
using CaseAPI.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("document/{documentId}")]
        public IActionResult Get(int documentId)
        {
            DocumentDto result = _documentService.GetById(documentId);
            return Ok(result);

        }

        [HttpPost("document")]
        public IActionResult Post([FromBody] DocumentDto documentDto)
        {
            _documentService.Create(documentDto);
            return StatusCode(201, "Created Successfully");
        }

        [HttpPost("document/{documentId}")]
        public IActionResult Post([FromBody] DocumentDto documentDto, int documentId)
        {
            _documentService.Update(documentDto, documentId);
            return Ok("Updated Successfully");
        }

        [HttpDelete("document/{documentId}")]
        public IActionResult Delete(int documentId)
        {
            _documentService.Delete(documentId);
            return Ok("Deleted Successfully");
        }
    }
}

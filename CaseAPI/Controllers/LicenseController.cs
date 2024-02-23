using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Mvc;
using CaseAPI.Models.caseproj;
using License = CaseAPI.Models.caseproj.License;
using CaseAPI.Models;
using AutoMapper;
using CaseAPI.Business.Abstracts;

namespace CaseAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly ILicenseService _licenseService;
        public LicenseController(ILicenseService licenseService)
        {
            _licenseService = licenseService;
        }

        [HttpGet("licenses")]
        public IActionResult Get()
        {
            ICollection<LicenseDto> result = _licenseService.GetAll();
            return Ok(result);

        }

        [HttpPost("license/{documentId}")]
        public IActionResult Post([FromBody] LicenseDto licenseDto, int documentId)
        {
            _licenseService.Create(licenseDto, documentId);
            return StatusCode(201, "Created Successfully");
        }

        [HttpDelete("license/{licenseId}")]
        public IActionResult Delete(int licenseId)
        {
            _licenseService.Delete(licenseId);
            return Ok("Deleted Successfully");
        }
    }
}

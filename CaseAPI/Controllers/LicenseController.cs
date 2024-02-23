using Microsoft.AspNetCore.Mvc;
using CaseAPI.Models;
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

        [HttpGet("license/{licenseId}")]
        public IActionResult Get(int licenseId)
        {
            LicenseDto result = _licenseService.GetById(licenseId);
            return Ok(result);

        }

        [HttpPost("license/{documentId}")]
        public IActionResult Post([FromBody] LicenseDto licenseDto, int documentId)
        {
            _licenseService.Create(licenseDto, documentId);
            return StatusCode(201, "Created Successfully");
        }

        [HttpPut("license/{licenseId}")]
        public IActionResult Put([FromBody] LicenseDto licenseDto, int licenseId)
        {
            _licenseService.Update(licenseDto, licenseId);
            return Ok("Updated Successfully");
        }


        [HttpDelete("license/{licenseId}")]
        public IActionResult Delete(int licenseId)
        {
            _licenseService.Delete(licenseId);
            return Ok("Deleted Successfully");
        }
    }
}

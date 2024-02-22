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
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ILicenseService _licenseService;
        public LicenseController(UnitOfWork uow, IMapper mapper, ILicenseService licenseService)
        {
            _uow = uow;
            _mapper = mapper;
            _licenseService = licenseService;
        }

        [HttpGet("license")]
        public IActionResult Get()
        {
            XPQuery<License> licenses = _uow.Query<License>();
            ICollection<LicenseDto> result = _mapper.Map<ICollection<LicenseDto>>(licenses);
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
            return StatusCode(201, "Deleted Successfully");
        }
    }
}

using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Mvc;
using CaseAPI.Models.caseproj;
using License = CaseAPI.Models.caseproj.License;
using CaseAPI.Models;
using AutoMapper;

namespace CaseAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class LicenseController : ControllerBase
    {
        private readonly UnitOfWork _uow;
        private readonly IMapper _mapper;
        public LicenseController(UnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
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
            Document document = (Document) _uow.GetObjectByKey(typeof(Document), documentId);
            License license = new License(_uow);
            license.Name = licenseDto.Name;
            license.Document = document;
            _uow.Save(license);
            _uow.CommitChanges();
            return StatusCode(201, "Created");
        }
    }
}

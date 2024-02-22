using AutoMapper;
using CaseAPI.Models;
using CaseAPI.Models.caseproj;
using DevExpress.Internal;

namespace CaseAPI.Core.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LicenseDto, License>();
            CreateMap<License, LicenseDto>();
            CreateMap<DocumentDto, Document>();
            CreateMap<Document, DocumentDto>();
        }
    }
}

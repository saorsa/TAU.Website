using AutoMapper;
using TAU.Website.Data.Entities;
using TAU.Website.Models;
using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website;

public class TauAutomapperProfile : Profile
{
    public TauAutomapperProfile()
    {
        CreateMap<Newsletter, NewsPaperBlock>().ReverseMap();
        CreateMap<WhitePaperDownload, WhitePaperBlock>().ReverseMap();
    }
}
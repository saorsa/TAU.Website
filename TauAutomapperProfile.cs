namespace TAU.Website;

using AutoMapper;
using TAU.Website.Data.Entities;
using TAU.Website.Models.Custom_Blocks;

public class TauAutomapperProfile : Profile
{
    public TauAutomapperProfile()
    {
        this.CreateMap<Newsletter, NewsletterViewModel>().ReverseMap();
        this.CreateMap<WhitePaper, WhitePaperViewModel>().ReverseMap();
    }
}
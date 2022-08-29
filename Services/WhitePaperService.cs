namespace TAU.Website.Services;

using AutoMapper;
using TAU.Website.Data;
using TAU.Website.Data.Entities;
using TAU.Website.Models.Custom_Blocks;
using Microsoft.EntityFrameworkCore;

public class WhitePaperService : IWhitePaperService
{
    private readonly TauDbContext _dbContext;
    private readonly IMapper _mapper;

    public WhitePaperService(TauDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<WhitePaperViewModel> CreateWhitePaperAsync(WhitePaperViewModel whitePaper)
    {
        var newWhitePaper = this._mapper.Map<WhitePaperViewModel, WhitePaper>(whitePaper);

        await this._dbContext.WhitePapers.AddAsync(newWhitePaper);
        await this._dbContext.SaveChangesAsync();

        return this._mapper.Map<WhitePaper, WhitePaperViewModel>(newWhitePaper);
    }

    public async Task SaveWhitePaperUrlAsync(WhitePaperUrlModel whitePaper)
    {
        var settings = await this._dbContext.Settings.FirstOrDefaultAsync();

        if (settings == null)
        {
            await this._dbContext.Settings.AddAsync(new Settings()
            {
                WhitePaperUrl = whitePaper.Url
            });
        }
        else
        {
            settings.WhitePaperUrl = whitePaper.Url;
            this._dbContext.Settings.Update(settings);
        }

        await this._dbContext.SaveChangesAsync();
    }

    public async Task<string> GetWhitePaperUrlAsync()
    {
        var whitePaperUrl = await this._dbContext.Settings.FirstOrDefaultAsync();

        return whitePaperUrl == null ? string.Empty : whitePaperUrl.WhitePaperUrl;
    }
}
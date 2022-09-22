using Piranha;

namespace TAU.Website.Services;

using AutoMapper;
using Data;
using Data.Entities;
using Models.Custom_Blocks;

public class WhitePaperService : IWhitePaperService
{
    private readonly TauDbContext _dbContext;
    private readonly IMapper _mapper;
    private readonly IApi _api;
    public WhitePaperService(TauDbContext dbContext, IMapper mapper, IApi api)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _api = api;
    }

    public async Task<WhitePaperBlock> CreateWhitePaperDownloadAsync(WhitePaperBlock whitePaper)
    {
        var newWhitePaper = this._mapper.Map<WhitePaperBlock, WhitePaperDownload>(whitePaper);

        await this._dbContext.WhitePaperDownloads.AddAsync(newWhitePaper);
        await this._dbContext.SaveChangesAsync();

        return this._mapper.Map<WhitePaperDownload, WhitePaperBlock>(newWhitePaper);
    }


    public async Task<string> GetWhitePaperUrlAsync(Guid pageId, Guid blockId)
    {
        var page = await _api.Pages.GetByIdAsync(pageId);
        return ((WhitePaperBlock)page.Blocks.First(b=>b.Id==blockId)).ContentUrl;
    }
}
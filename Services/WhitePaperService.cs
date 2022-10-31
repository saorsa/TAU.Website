using AutoMapper;
using Piranha;
using TAU.Website.Data;
using TAU.Website.Data.Entities;
using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website.Services;

public class WhitePaperService : IWhitePaperService
{
    private readonly IApi _api;
    private readonly TauDbContext _dbContext;
    private readonly IMapper _mapper;

    public WhitePaperService(TauDbContext dbContext, IMapper mapper, IApi api)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _api = api;
    }

    public async Task<WhitePaperBlock> CreateWhitePaperDownloadAsync(WhitePaperBlock whitePaper)
    {
        var newWhitePaper = _mapper.Map<WhitePaperBlock, WhitePaperDownload>(whitePaper);

        await _dbContext.WhitePaperDownloads.AddAsync(newWhitePaper);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<WhitePaperDownload, WhitePaperBlock>(newWhitePaper);
    }


    public async Task<string> GetWhitePaperUrlAsync(Guid pageId, Guid blockId)
    {
        var page = await _api.Pages.GetByIdAsync(pageId);
        return ((WhitePaperBlock)page.Blocks.First(b => b.Id == blockId)).ContentUrl;
    }
}
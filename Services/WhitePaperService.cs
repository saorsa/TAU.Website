namespace TAU.Website.Services;

using AutoMapper;
using TAU.Website.Data;
using TAU.Website.Data.Entities;
using TAU.Website.Models.Custom_Blocks;

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
}
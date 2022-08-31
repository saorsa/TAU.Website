using TAU.Website.Models;

namespace TAU.Website.Services;

using AutoMapper;
using TAU.Website.Data;
using TAU.Website.Data.Entities;
using TAU.Website.Models.Custom_Blocks;

public class NewsletterService : INewsletterService
{
    private readonly TauDbContext _dbContext;
    private readonly IMapper _mapper;

    public NewsletterService(TauDbContext dbContext, IMapper mapper)
    {
        this._dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NewsPaperBlock> CreateNewsletterAsync(NewsPaperBlock newsletter)
    {
        var newNewsletter = this._mapper.Map<NewsPaperBlock, Newsletter>(newsletter);

        await this._dbContext.Newsletters.AddAsync(newNewsletter);
        await this._dbContext.SaveChangesAsync();

        return this._mapper.Map<Newsletter, NewsPaperBlock>(newNewsletter);
    }
}
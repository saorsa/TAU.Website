using AutoMapper;
using TAU.Website.Data;
using TAU.Website.Data.Entities;
using TAU.Website.Models;

namespace TAU.Website.Services;

public class NewsletterService : INewsletterService
{
    private readonly TauDbContext _dbContext;
    private readonly IMapper _mapper;

    public NewsletterService(TauDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<NewsPaperBlock> CreateNewsletterAsync(NewsPaperBlock newsletter)
    {
        var newNewsletter = _mapper.Map<NewsPaperBlock, Newsletter>(newsletter);

        await _dbContext.Newsletters.AddAsync(newNewsletter);
        await _dbContext.SaveChangesAsync();

        return _mapper.Map<Newsletter, NewsPaperBlock>(newNewsletter);
    }
}
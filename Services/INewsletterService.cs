using TAU.Website.Models;

namespace TAU.Website.Services;

public interface INewsletterService
{
    Task<NewsPaperBlock> CreateNewsletterAsync(NewsPaperBlock newsletter);
}
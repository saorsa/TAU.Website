using TAU.Website.Models;

namespace TAU.Website.Services;

using TAU.Website.Models.Custom_Blocks;

public interface INewsletterService
{
    Task<NewsPaperBlock> CreateNewsletterAsync(NewsPaperBlock newsletter);
}
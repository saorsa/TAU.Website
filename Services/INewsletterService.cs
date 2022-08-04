namespace TAU.Website.Services;

using TAU.Website.Models.Custom_Blocks;

public interface INewsletterService
{
    Task<NewsletterViewModel> CreateNewsletterAsync(NewsletterViewModel newsletter);
}
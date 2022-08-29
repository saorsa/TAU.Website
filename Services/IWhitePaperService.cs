namespace TAU.Website.Services;

using TAU.Website.Models.Custom_Blocks;

public interface IWhitePaperService
{
    Task<WhitePaperViewModel> CreateWhitePaperAsync(WhitePaperViewModel whitePaper);

    Task SaveWhitePaperUrlAsync(WhitePaperUrlModel whitePaper);

    Task<string> GetWhitePaperUrlAsync();
}
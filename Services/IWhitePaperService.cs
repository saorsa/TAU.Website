using TAU.Website.Models.Custom_Blocks;

namespace TAU.Website.Services;

public interface IWhitePaperService
{
    Task<WhitePaperBlock> CreateWhitePaperDownloadAsync(WhitePaperBlock whitePaper);


    Task<string> GetWhitePaperUrlAsync(Guid pageId, Guid blockId);
}
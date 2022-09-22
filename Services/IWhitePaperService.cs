using TAU.Website.Models;

namespace TAU.Website.Services;

using TAU.Website.Models.Custom_Blocks;

public interface IWhitePaperService
{
    Task<WhitePaperBlock> CreateWhitePaperDownloadAsync(WhitePaperBlock whitePaper);


    Task<string> GetWhitePaperUrlAsync(Guid pageId, Guid blockId);
}
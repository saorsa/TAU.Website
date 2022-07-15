namespace TAU.Website.Services;

public interface ISeedService
{
    Task<string> SeedData(
        CancellationToken cancellationToken = default);
}
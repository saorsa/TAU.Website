using System.Net;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using TAU.Website.Models.GoogleReCaptchaResponse;

namespace TAU.Website.Services;

public class GoogleReCaptchaService
{
    private readonly IOptionsMonitor<GoogleReCaptchaConfig> _googleReCaptchaConfig;

    public GoogleReCaptchaService(IOptionsMonitor<GoogleReCaptchaConfig> googleReCaptchaConfig)
    {
        _googleReCaptchaConfig = googleReCaptchaConfig;
    }

    public async Task<bool> Verify(string token)
    {
        var url =
            $"https://www.google.com/recaptcha/api/siteverify?secret={_googleReCaptchaConfig.CurrentValue.SecretKey}&response={token}";

        using (var client = new HttpClient())
        {
            var httpResult = await client.GetAsync(url);
            if (httpResult.StatusCode != HttpStatusCode.OK) return false;

            var responseString = await httpResult.Content.ReadAsStringAsync();

            var googleResult = JsonConvert.DeserializeObject<GoogleReCaptchaResponseModel>(responseString);

            return googleResult.Success && googleResult.Score >= 0.5;
        }
    }
}
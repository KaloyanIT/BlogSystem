using Blog.Infrastructure.Options;
using Blog.Services.ReCaptcha.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Blog.Services.ReCaptcha
{
    public class ReCaptchaVerificationService : IReCaptchaVerificationService
    {
        private readonly ILogger<ReCaptchaVerificationService> _logger;
        private readonly GoogleRecaptchaOptions _googleRecaptchaOptions;

        private readonly string _googleVerificationUrl = "https://www.google.com/recaptcha/api/siteverify";

        public ReCaptchaVerificationService(
            ILogger<ReCaptchaVerificationService> logger,
            IOptions<GoogleRecaptchaOptions> options)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _googleRecaptchaOptions = options.Value;
        }

        public async Task<bool> IsCaptchaValid(CaptchaRequestModel captchaRequestModel)
        {
            try
            {
                using var client = new HttpClient();

                var response = await client.PostAsync($"{_googleVerificationUrl}?secret={_googleRecaptchaOptions.SecretKey}&response={captchaRequestModel.Response}&remoteIp={captchaRequestModel.RemoteIp}", null);
                var jsonString = await response.Content.ReadAsStringAsync();
                var captchaVerification = JsonConvert.DeserializeObject<CaptchaResponseModel>(jsonString);

                return captchaVerification.Success;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed captcha.", ex);
                return false;
            }
        }
    }
}

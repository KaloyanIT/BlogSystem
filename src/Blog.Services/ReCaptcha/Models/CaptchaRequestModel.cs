using System;

namespace Blog.Services.ReCaptcha.Models
{
    public class CaptchaRequestModel
    {
        public string Path { get; private set; } = null!;

        public string Secret { get; private set; } = null!;

        public string Response { get; private set; }

        public string RemoteIp { get; private set; }

        public CaptchaRequestModel(string response, string remoteIp)
        {
            if (string.IsNullOrWhiteSpace(response))
            {
                throw new ArgumentException($"'{nameof(response)}' cannot be null or empty.", nameof(response));
            }

            if (string.IsNullOrWhiteSpace(remoteIp))
            {
                throw new ArgumentException($"'{nameof(remoteIp)}' cannot be null or empty.", nameof(remoteIp));
            }

            Response = response;
            RemoteIp = remoteIp;
        }

        public void SetPath(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException($"'{nameof(path)}' cannot be null or empty.", nameof(path));
            }

            Path = path;
        }

        public void SetSecret(string secret)
        {
            if (string.IsNullOrWhiteSpace(secret))
            {
                throw new ArgumentException($"'{nameof(secret)}' cannot be null or empty.", nameof(secret));
            }

            Secret = secret;
        }
    }
}

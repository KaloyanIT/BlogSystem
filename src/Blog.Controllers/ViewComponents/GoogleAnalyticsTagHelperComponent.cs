using System;
using System.Threading.Tasks;
using Blog.Infrastructure.Options;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;

namespace Blog.Controllers.ViewComponents
{
    public class GoogleAnalyticsTagHelperComponent : TagHelperComponent
    {
        private readonly GoogleAnalyticsOptions _googleAnalyticsOptions;

        public GoogleAnalyticsTagHelperComponent(IOptions<GoogleAnalyticsOptions> googleAnalyticsOptions)
        {
            _googleAnalyticsOptions = googleAnalyticsOptions.Value;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await Task.Run(() =>
            {
                if (string.Equals(output.TagName, "head", StringComparison.OrdinalIgnoreCase))
                {
                    // Get the tracking code from the configuration
                    var trackingCode = _googleAnalyticsOptions.TrackingCode;
                    if (!string.IsNullOrEmpty(trackingCode))
                    {
                        // PostContent correspond to the text just before closing tag
                        output.PostContent
                            .AppendHtml("<script async src='https://www.googletagmanager.com/gtag/js?id=")
                            .AppendHtml(trackingCode)
                            .AppendHtml("'></script><script>window.dataLayer=window.dataLayer||[];function gtag(){dataLayer.push(arguments)}gtag('js',new Date);gtag('config','")
                            .AppendHtml(trackingCode)
                            .AppendHtml("',{displayFeaturesTask:'null'});</script>");
                    }
                }
            });
        }
    }
}

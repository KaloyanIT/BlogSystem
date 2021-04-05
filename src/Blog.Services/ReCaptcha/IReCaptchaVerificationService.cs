using Blog.Services.Base;
using Blog.Services.ReCaptcha.Models;
using System.Threading.Tasks;

namespace Blog.Services.ReCaptcha
{
    public interface IReCaptchaVerificationService : IService
    {
        Task<bool> IsCaptchaValid(CaptchaRequestModel requestModel);
    }
}

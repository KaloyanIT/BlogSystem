namespace Blog.Controllers.FrontEnd
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.EmailService;
    using Blog.Infrastructure.Options;
    using Blog.Services.ContactData;
    using Blog.Services.ContactData.Models;
    using Blog.ViewModels.FrontEnd.ContactData;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;

    public class ContactController : Controller
    {
        private readonly IContactDataService _contactDataService;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        private readonly GoogleRecaptchaOptions _googleRecaptcha;

        public ContactController(IContactDataService contactDataService,
            IOptions<GoogleRecaptchaOptions> recaptchaOptions,
            IEmailSender emailSender,
            IMapper mapper)
        {
            _contactDataService = contactDataService;
            _emailSender = emailSender;
            _googleRecaptcha = recaptchaOptions.Value;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            ViewData["SiteKey"] = _googleRecaptcha.SiteKey;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDataViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            var serviceModel = _mapper.Map<CreateContactDataServiceModel>(viewModel);

            var model = await _contactDataService.Create(serviceModel);

            await _emailSender.Send(model.Email, "Contact message recieved!", "Hi");

            ViewData["SiteKey"] = _googleRecaptcha.SiteKey;

            return RedirectToAction("Index");
        }
    }
}

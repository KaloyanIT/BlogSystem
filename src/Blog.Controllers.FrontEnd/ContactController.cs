﻿namespace Blog.Controllers.FrontEnd
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using EmailService;
    using Infrastructure.Options;
    using Services.ContactData;
    using Services.ContactData.Models;
    using Blog.ViewModels.FrontEnd.ContactData;
    using Infrastructure.Constants;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class ContactController : Controller
    {
        private readonly IContactDataService _contactDataService;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<ContactController> _logger;
        private readonly IMapper _mapper;
        private readonly GoogleRecaptchaOptions _googleRecaptcha;

        public ContactController(IContactDataService contactDataService,
            IOptions<GoogleRecaptchaOptions> recaptchaOptions,
            IEmailSender emailSender,
            ILogger<ContactController> logger,
            IMapper mapper)
        {
            _contactDataService = contactDataService;
            _emailSender = emailSender;
            _logger = logger;
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
            if (!ModelState.IsValid)
            {
                return View("Index", viewModel);
            }

            try
            {
                var serviceModel = _mapper.Map<CreateContactDataServiceModel>(viewModel);

                var model = await _contactDataService.Create(serviceModel);

                await _emailSender.Send(model.Email, "Thank you!", "Hi");

                TempData[MessagesConstants.TempDataSuccessMessageKey] = MessagesConstants.ContactSuccessMessage;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Contact page error");

                TempData[MessagesConstants.TempDataErrorMessageKey] = MessagesConstants.ContactErrorMessage;
            }

            ViewData["SiteKey"] = _googleRecaptcha.SiteKey;

            return RedirectToAction("Index");
        }
    }
}

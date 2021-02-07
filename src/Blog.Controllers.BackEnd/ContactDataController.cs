namespace Blog.Controllers.BackEnd
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Base;
    using Data.Base.Extensions;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Services.ContactData;
    using ViewModels.BackEnd.ContactsData;

    [Area("Admin")]
    public class ContactDataController : BackEndController
    {
        private readonly IContactDataService _contactDataService;

        public ContactDataController(
            IContactDataService contactDataService,
            ILogger<BackEndController> logger,
            IMapper mapper) : base(logger, mapper)
        {
            _contactDataService = contactDataService;
        }

        public IActionResult Index(int page = 1)
        {
            var contactsData = _contactDataService.GetAll()
                .OrderByDescending(x => x.DateCreated)
                .To<ContactDataViewModel>()
                .GetPaged(page, MaxPageSize);

            return View(contactsData);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var contactData = await _contactDataService.GetById(id);

            if(contactData == null)
            {
                return NotFound();
            }

            var viewModel = Mapper.Map<DetailedContactDataViewModel>(contactData);            

            return View(viewModel);
        }
    }
}

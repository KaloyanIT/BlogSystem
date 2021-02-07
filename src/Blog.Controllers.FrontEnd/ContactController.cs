namespace Blog.Controllers.FrontEnd
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Blog.Services.ContactData;
    using Blog.Services.ContactData.Models;
    using Blog.ViewModels.FrontEnd.ContactData;
    using Microsoft.AspNetCore.Mvc;

    public class ContactController : Controller
    {
        private readonly IContactDataService _contactDataService;
        private readonly IMapper _mapper;

        public ContactController(IContactDataService contactDataService, 
            IMapper mapper)
        {
            _contactDataService = contactDataService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
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

            return RedirectToAction("Index");
        }
    }
}

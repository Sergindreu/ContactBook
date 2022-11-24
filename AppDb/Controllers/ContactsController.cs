using AppDb.Models;
using AppDb.Service;
using Microsoft.AspNetCore.Mvc;

namespace AppDb.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsService _service;
        public ContactsController(ContactsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Email,Phone")]Contacts contact)
        {
            if(!ModelState.IsValid)
            {
                return View( contact);
            }
           _service.Create(contact);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var contactDetail = await _service.GetById(id);
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}

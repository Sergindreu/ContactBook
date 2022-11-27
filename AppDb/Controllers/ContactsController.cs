using AppDb.Models;
using AppDb.Service;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

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

        public IActionResult Edit()
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

        [HttpPost]
        public async Task<IActionResult> Update(int id,[Bind("Id,Name,Email,Phone")]Contacts contact)
        {
            await _service.Update(id,contact);
            return RedirectToAction(nameof(Edit));
        }

        public async Task<IActionResult> ExportExel()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                            new DataColumn("Name"),
                                            new DataColumn("Email"),
                                            new DataColumn("Phone") });

            var customers = await _service.GetAll();
            foreach (var customer in customers)
            {
                dt.Rows.Add(customer.Id, customer.Name, customer.Email, customer.Phone);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Repo.xlsx");
                }
            }



        }

    }
}

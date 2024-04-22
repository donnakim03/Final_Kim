/*
 * Donna Kim
 * Section 3
 * Description: Web app that shows entertainers in the database and has CRUD functionality
 */

using Final_Kim.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Final_Kim.Controllers
{
    public class HomeController : Controller
    {
        private IEntertainmentRepository _repo;

        public HomeController(IEntertainmentRepository temp)
        {
            _repo = temp;
        }

        // returns home page
        public IActionResult Index()
        {
            return View();
        }

        // Returns a page that shows all the entertainers
        public IActionResult EntertainerList()
        {
            var entertainers = _repo.Entertainers
                .OrderBy(x => x.EntStageName);

            return View(entertainers);
        }

        // Returns the form to fill out entertainer info
        [HttpGet]
        public IActionResult EntertainerForm()
        {
            return View(new Entertainer());
        }

        // Creates new entertainer
        [HttpPost]
        public IActionResult EntertainerForm(Entertainer ent)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEntertainer(ent);
            }
            return View("Confirmation");
        }

        // Shows details for one specific entertainer chosen by the user
        public IActionResult EntertainerDetails(int id)
        {
            var entertainerToView = _repo.Entertainers
                .Single(x => x.EntertainerId == id);

            return View("EntertainerDetails", entertainerToView);
        }

        //Edit entertainer info get and post
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entertainerToView = _repo.Entertainers
                .Single(x => x.EntertainerId == id);

            return View("EntertainerForm", entertainerToView);
        }

        [HttpPost]
        public IActionResult Edit(Entertainer ent)
        {
            _repo.EditEntertainer(ent);
            return RedirectToAction("EntertainerList");
        }

        //Delete entertainer info get and post
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entertainerToDelete = _repo.Entertainers
                .Single(x => x.EntertainerId == id);

            return View(entertainerToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Entertainer ent)
        {
            _repo.DeleteEntertainer(ent);

            return RedirectToAction("EntertainerList");
        }
    }
}

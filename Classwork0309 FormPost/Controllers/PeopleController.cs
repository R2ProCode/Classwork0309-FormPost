using Classwork0309_FormPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Classwork0309_FormPost.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        public ActionResult Index()
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            PeopleViewModel viewModel = new PeopleViewModel
            {
                People = dbManager.GetAllPeople()
            };
            return View(viewModel);
        }

        public ActionResult AddPersonForm()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddPerson(string firstname, string lastname, int age)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbManager.AddPerson(firstname, lastname, age);
            return Redirect("/people/index");
        }
        [HttpPost]
        public ActionResult DeletePerson(int id)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbManager.DeletePerson(id);
            return Redirect("/people/index");
        }

        public ActionResult EditPersonForm(int id)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            Person person = dbManager.GetPersonById(id);

            EditPersonViewModel viewModel = new EditPersonViewModel
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age = person.Age
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UpdatePerson(int id, string firstName, string lastName, int age)
        {
            PeopleDbManager dbmanager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbmanager.UpdatePerson(id, firstName, lastName, age);
            return Redirect("/people/index");
        }
    }
}
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
        public ActionResult Add(string firstname, string lastname, int age)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbManager.AddPerson(firstname, lastname, age);
            return Redirect("/people/index");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbManager.DeletePerson(id);
            return Redirect("/people/index");
        }

        public ActionResult Edit(int id)
        {
            PeopleDbManager dbManager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            Person person = dbManager.GetPersonById(id);

            EditPersonViewModel viewModel = new EditPersonViewModel
            {
                Person = person
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Update(Person person)
        {
            PeopleDbManager dbmanager = new PeopleDbManager(Properties.Settings.Default.ConStr);
            dbmanager.UpdatePerson(person);
            return Redirect("/people/index");
        }
    }
}
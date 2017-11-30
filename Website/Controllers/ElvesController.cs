using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ElvesController : Controller
    {
        /// <summary>
        /// This page should simply load a paginated list of all elves
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            return View();
        }

        /// <summary>
        /// This page should show all relevant data about a given elf. Such data includes the elf's name, salary, presents made, salary:presents ratio, and any reindeer they take care of.
        /// </summary>
        /// <param name="elfId"></param>
        /// <returns></returns>
        public ActionResult Details(int elfId)
        {
            return View();
        }

        /// <summary>
        /// This page should allow the user to edit an elf's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int kidId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int kidId, bool tempParameterPleaseRemoveThis) //Needs a request view model
        {
            return View();
        }

        /// <summary>
        /// This page should allow the user to create a new elf in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(bool tempParameterPleaseRemoveThis) //Needs a request view model
        {
            return View();
        }
    }
}
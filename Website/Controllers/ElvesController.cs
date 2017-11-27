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
    }
}
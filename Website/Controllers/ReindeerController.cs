using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class ReindeerController : Controller
    {
        /// <summary>
        /// This page should simply show a paginated list of reindeer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            return View();
        }

        /// <summary>
        /// This page should show data on a reindeer, such as its status and a link to its caretaker elf.
        /// </summary>
        /// <param name="reindeerId"></param>
        /// <returns></returns>
        public ActionResult Details(int reindeerId)
        {
            return View();
        }
    }
}
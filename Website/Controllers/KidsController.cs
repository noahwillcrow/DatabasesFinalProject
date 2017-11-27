using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Website.Controllers
{
    public class KidsController : Controller
    {
        /// <summary>
        /// This page should simply load a paginated list of kids
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            return View();
        }

        /// <summary>
        /// This page should load details about the specific kid, given the kid Id, and return a view with the relevant data.
        /// Such data would include all the kid's actions, the presents being prepared for them, and their status on naughty/nice list.
        /// </summary>
        /// <param name="kidId">The ID of the kid to load data about</param>
        /// <returns></returns>
        public ActionResult Details(int kidId)
        {
            return View();
        }

        /// <summary>
        /// This page should show a paginated list of all children who are either naughty or nice, as determined by the nice parameter
        /// </summary>
        /// <param name="nice">Whether to load the nice list or the naughty list</param>
        /// <returns></returns>
        public ActionResult List(bool nice, int page = 1)
        {
            return View();
        }

        /// <summary>
        /// This page should show a list of all houses in which all kids are nice and receiving presents
        /// </summary>
        /// <returns></returns>
        public ActionResult GoodHouses(int page = 1)
        {
            return View();
        }
    }
}
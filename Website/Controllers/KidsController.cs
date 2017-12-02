using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models.Request;
using Website.Models.Response;

namespace Website.Controllers
{
    public class KidsController : Controller
    {
        /// <summary>
        /// This page should simply load a paginated list of kids
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var kids = KidsManager.GetAll();
            return View(kids);
        }

        /// <summary>
        /// This page should load details about the specific kid, given the kid Id, and return a view with the relevant data.
        /// Such data would include all the kid's actions, the presents being prepared for them, and their status on naughty/nice list.
        /// </summary>
        /// <param name="kidId">The ID of the kid to load data about</param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var kid = KidsManager.GetByID(id);
            if (kid == null)
            {
                return RedirectToAction("Index");
            }

            var isNice = KidsManager.IsKidNice(id);
            var deeds = KidsManager.GetDeeds(id);
            var presents = KidsManager.GetPresents(id);

            var viewModel = new KidDetailsViewModel(kid, isNice, deeds, presents);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit a kid's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var kid = KidsManager.GetByID(id);
            var viewModel = new KidUpdateResponseViewModel(kid);
            return View("~/Views/Kids/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, KidUpdateRequestViewModel requestModel)
        {
            var kid = KidsManager.GetByID(id);
            requestModel.UpdateKidModel(kid);

            bool success = KidsManager.Save(kid);

            var viewModel = new KidUpdateResponseViewModel(kid);
            viewModel.UpdateSuccess = success;

            return View("~/Views/Kids/AddOrUpdate.cshtml", viewModel);
        }

        /// <summary>
        /// This page should allow the user to create a new kid in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("~/Views/Kids/AddOrUpdate.cshtml", new KidUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(KidUpdateRequestViewModel requestModel)
        {
            var kid = new Kid();
            requestModel.UpdateKidModel(kid);

            bool success = KidsManager.Save(kid);

            var viewModel = new KidUpdateResponseViewModel(kid);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { id = kid.ID });
        }

        /// <summary>
        /// This page should show a paginated list of all children who are either naughty or nice, as determined by the nice parameter
        /// </summary>
        /// <param name="nice">Whether to load the nice list or the naughty list</param>
        /// <returns></returns>
        public ActionResult List(bool nice)
        {
            var kids = KidsManager.GetList(nice);
            return View("~/Views/Kids/Index.cshtml", kids);
        }

        /// <summary>
        /// This page should show a list of all houses in which all kids are nice and receiving presents
        /// </summary>
        /// <returns></returns>
        public ActionResult GoodHouses()
        {
            var goodHouses = HousesManager.GetHousesWithOnlyNiceKids();
            return View(goodHouses);
        }
    }
}
using DatabaseBridge.Managers;
using DatabaseBridge.Models;
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
        public ActionResult Index(int page = 1)
        {
            var kids = KidsManager.GetPage(pagesize: 10, pagenumber: page);
            return View(kids);
        }

        /// <summary>
        /// This page should load details about the specific kid, given the kid Id, and return a view with the relevant data.
        /// Such data would include all the kid's actions, the presents being prepared for them, and their status on naughty/nice list.
        /// </summary>
        /// <param name="kidId">The ID of the kid to load data about</param>
        /// <returns></returns>
        public ActionResult Details(int kidId)
        {
            var kid = KidsManager.GetByID(kidId);
            var isNice = KidsManager.IsKidNice(kidId);
            var deeds = KidsManager.GetDeeds(kidId);
            var presents = KidsManager.GetPresents(kidId);

            var viewModel = new KidDetailsViewModel(kid, isNice, deeds, presents);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit a kid's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int kidId)
        {
            var kid = KidsManager.GetByID(kidId);
            var viewModel = new KidUpdateResponseViewModel(kid);
            return View("~/Views/Kids/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int kidId, KidUpdateRequestViewModel requestModel)
        {
            var kid = KidsManager.GetByID(kidId);
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
            return View("~/Views/Kids/AddOrUpdate.cshtml");
        }

        [HttpPost]
        public ActionResult Create(KidUpdateRequestViewModel requestModel)
        {
            var kid = new Kid();
            requestModel.UpdateKidModel(kid);

            bool success = KidsManager.Save(kid);

            var viewModel = new KidUpdateResponseViewModel(kid);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { kidId = kid.ID });
        }

        /// <summary>
        /// This page should show a paginated list of all children who are either naughty or nice, as determined by the nice parameter
        /// </summary>
        /// <param name="nice">Whether to load the nice list or the naughty list</param>
        /// <returns></returns>
        public ActionResult List(bool nice, int page = 1)
        {
            var kids = KidsManager.GetPaginatedList(nice, pagesize: 10, pagenumber: page);
            return View(kids);
        }

        /// <summary>
        /// This page should show a list of all houses in which all kids are nice and receiving presents
        /// </summary>
        /// <returns></returns>
        public ActionResult GoodHouses(int page = 1)
        {
            var goodHouses = HousesManager.GetHousesWithOnlyNiceKids(pagesize: 10, pagenumber: page);
            return View(goodHouses);
        }
    }
}
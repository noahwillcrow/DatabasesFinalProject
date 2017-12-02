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
        [Route("/kids")]
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
        [Route("/kids/details/{kidId}")]
        public ActionResult Details(int kidId)
        {
            var kid = KidsManager.GetByID(kidId);
            var isNice = KidsManager.IsKidNice(kidId);
            var deeds = KidsManager.GetDeeds(kidId);
            var presents = KidsManager.GetPresents(kidId);
            var presentItemNames = new List<string>();

            foreach (var present in presents)
            {
                var item = DataManager<Item>.GetByID(present.ItemID);
                presentItemNames.Add(item.Name);
            }

            var viewModel = new KidDetailsViewModel(kid, isNice, deeds, presentItemNames);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit a kid's records.
        /// </summary>
        /// <returns></returns>
        [Route("/kids/update/{kidId}")]
        public ActionResult Update(int kidId)
        {
            var kid = KidsManager.GetByID(kidId);
            var viewModel = new KidUpdateResponseViewModel(kid);
            return View("~/Views/Kids/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        [Route("/kids/update/{kidId}")]
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
        [Route("/kids/create")]
        public ActionResult Create()
        {
            return View("~/Views/Kids/AddOrUpdate.cshtml");
        }

        [HttpPost]
        [Route("/kids/create")]
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
        [Route("/kids/list/{nice}")]
        public ActionResult List(bool nice)
        {
            var kids = KidsManager.GetList(nice);
            return View(kids);
        }

        /// <summary>
        /// This page should show a list of all houses in which all kids are nice and receiving presents
        /// </summary>
        /// <returns></returns>
        [Route("/kids/good-houses")]
        public ActionResult GoodHouses()
        {
            var goodHouses = HousesManager.GetHousesWithOnlyNiceKids();
            return View(goodHouses);
        }
    }
}
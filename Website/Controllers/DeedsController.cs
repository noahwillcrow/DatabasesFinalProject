using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Web.Mvc;
using Website.Models.Request;
using Website.Models.Response;

namespace Website.Controllers
{
    public class DeedsController : Controller
    {
        /// <summary>
        /// This page should simply load a paginated list of all deeds
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var deeds = DeedsManager.GetAll();
            return View(deeds);
        }

        /// <summary>
        /// This page should show all relevant data about a given deed. Such data includes the date, what happened, who did it, if it was naughty or nice, etc...
        /// </summary>
        /// <param name="elfId"></param>
        /// <returns></returns>
        public ActionResult Details(int id, System.DateTime timeOfDeed)
        {
            var deed = DeedsManager.GetDeeds(id, timeOfDeed);
            if (deed == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new DeedDetailsViewModel(deed);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit a deed's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id, System.DateTime timeOfDeed)
        {
            var deed = DeedsManager.GetDeeds(id, timeOfDeed);
            var viewModel = new DeedUpdateResponseViewModel(deed);
            return View("~/Views/Deeds/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, System.DateTime timeOfDeed, DeedUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var deed = DeedsManager.GetDeeds(id, timeOfDeed);
            requestModel.UpdateDeedModel(deed);

            bool success = DeedsManager.Save(deed);

            var viewModel = new DeedUpdateResponseViewModel(deed);
            viewModel.UpdateSuccess = success;

            return View("~/Views/Deeds/AddOrUpdate.cshtml", viewModel);
        }

        /// <summary>
        /// This page should allow the user to create a new deed in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("~/Views/Deeds/AddOrUpdate.cshtml", new DeedUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(DeedUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var deed = new Deed();
            requestModel.UpdateDeedModel(deed);

            bool success = DeedsManager.Save(deed);

            var viewModel = new DeedUpdateResponseViewModel(deed);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { kidId = deed.KidID, timeOfDeed = deed.TimeOfDeed });
        }
    }
}
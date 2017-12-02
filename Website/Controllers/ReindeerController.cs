using System.Web.Mvc;
using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using Website.Models.Response;
using Website.Models.Request;

namespace Website.Controllers
{
    public class ReindeerController : Controller
    {
        /// <summary>
        /// This page should simply show a paginated list of reindeer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var reindeer = DataManager<Reindeer>.GetAll();
            return View(reindeer);
        }

        /// <summary>
        /// This page should show data on a reindeer, such as its status and a link to its caretaker elf.
        /// </summary>
        /// <param name="reindeerId"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var reindeer = DataManager<Reindeer>.GetByID(id);
            var viewModel = new ReindeerDetailsViewModel(reindeer);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit a reindeer's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var reindeer = DataManager<Reindeer>.GetByID(id);
            var viewModel = new ReindeerUpdateResponseViewModel(reindeer);
            return View("~/Views/Reindeer/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, ReindeerUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var reindeer = DataManager<Reindeer>.GetByID(id);
            requestModel.UpdateReindeerModel(reindeer);

            bool success = DataManager<Reindeer>.Save(reindeer);

            var viewModel = new ReindeerUpdateResponseViewModel(reindeer);
            viewModel.UpdateSuccess = success;


            return View("~/Views/Reindeer/AddOrUpdate.cshtml", viewModel);
        }

        /// <summary>
        /// This page should allow the user to create a new reindeer in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("~/Views/Reindeer/AddOrUpdate.cshtml", new ReindeerUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(ReindeerUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var reindeer = new Reindeer();
            requestModel.UpdateReindeerModel(reindeer);

            bool success = DataManager<Reindeer>.Save(reindeer);

            var viewModel = new ReindeerUpdateResponseViewModel(reindeer);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { id = reindeer.ID });
        }
    }
}
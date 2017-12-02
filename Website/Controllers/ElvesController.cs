using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Web.Mvc;
using Website.Models.Request;
using Website.Models.Response;

namespace Website.Controllers
{
    public class ElvesController : Controller
    {
        /// <summary>
        /// This page should simply load a paginated list of all elves
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var elves = ElvesManager.GetAll();
            return View(elves);
        }

        /// <summary>
        /// This page should show all relevant data about a given elf. Such data includes the elf's name, salary, presents made, salary:presents ratio, and any reindeer they take care of.
        /// </summary>
        /// <param name="elfId"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var elf = ElvesManager.GetByID(id);
            if (elf == null)
            {
                return RedirectToAction("Index");
            }

            var ratio = ElvesManager.GetSalaryToPresentsRatio(id);
            var reindeer = ElvesManager.GetPresents(id);
            var presents = ElvesManager.GetReindeer(id);

            var viewModel = new ElfDetailsViewModel(elf, ratio, presents, reindeer);
            return View(viewModel);
        }

        /// <summary>
        /// This page should allow the user to edit an elf's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var elf = ElvesManager.GetByID(id);
            var viewModel = new ElfUpdateResponseViewModel(elf);
            return View("~/Views/Elves/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, ElfUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var elf = ElvesManager.GetByID(id);
            requestModel.UpdateElfModel(elf);

            bool success = ElvesManager.Save(elf);

            var viewModel = new ElfUpdateResponseViewModel(elf);
            viewModel.UpdateSuccess = success;


            return View("~/Views/Elves/AddOrUpdate.cshtml", viewModel);
        }

        /// <summary>
        /// This page should allow the user to create a new elf in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("~/Views/Elves/AddOrUpdate.cshtml", new ElfUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(ElfUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var elf = new Elf();
            requestModel.UpdateElfModel(elf);

            bool success = ElvesManager.Save(elf);

            var viewModel = new ElfUpdateResponseViewModel(elf);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { id = elf.ID });
        }
    }
}
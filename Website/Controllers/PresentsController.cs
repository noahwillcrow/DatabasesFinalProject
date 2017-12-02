using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Website.Models.Request;
using Website.Models.Response;

namespace Website.Controllers
{
    public class PresentsController : Controller
    {
        public ActionResult Index()
        {
            var presents = PresentsManager.GetAll();
            var viewModel = new List<PresentDetailsViewModel>();

            foreach (var present in presents)
            {
                viewModel.Add(new PresentDetailsViewModel(present));
            }

            return View(viewModel);
        }

        public ActionResult Details(int kidId, int itemId)
        {
            var present = PresentsManager.GetPresent(kidId, itemId);
            if (present == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new PresentDetailsViewModel(present);

            return View(viewModel);
        }

        public ActionResult Update(int kidId, int itemId)
        {
            var present = PresentsManager.GetPresent(kidId, itemId);
            var viewModel = new PresentUpdateResponseViewModel(present);
            return View("~/Views/Presents/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int kidId, int itemId, PresentUpdateRequestViewModel requestModel)
        {
            var present = PresentsManager.GetPresent(kidId, itemId);
            requestModel.UpdatePresentModel(present);

            bool success = PresentsManager.Save(present);

            var viewModel = new PresentUpdateResponseViewModel(present);
            viewModel.UpdateSuccess = success;

            return View("~/Views/Presents/AddOrUpdate.cshtml", viewModel);
        }

        public ActionResult Create()
        {
            return View("~/Views/Presents/AddOrUpdate.cshtml", new PresentUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(PresentUpdateRequestViewModel requestModel)
        {
            var present = new Present();
            requestModel.UpdatePresentModel(present);

            bool success = PresentsManager.Save(present);

            return RedirectToAction("Details", new { kidId = present.KidID, itemId = present.ItemID });
        }
    }
}
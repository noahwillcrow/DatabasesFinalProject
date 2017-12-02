using System.Web.Mvc;
using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using Website.Models.Response;
using Website.Models.Request;

namespace Website.Controllers
{
    public class ItemController : Controller
    {
        /// <summary>
        /// This page should simply show a paginated list of items.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var item = DataManager<Item>.GetAll();
            return View(item);
        }

        /// <summary>
        /// This page should allow the user to edit a reindeer's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int id)
        {
            var item = DataManager<Item>.GetByID(id);
            var viewModel = new ItemUpdateResponseViewModel(item);
            return View("~/Views/Item/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, ItemUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var item = DataManager<Item>.GetByID(id);
            requestModel.UpdateItemModel(item);

            bool success = DataManager<Item>.Save(item);

            var viewModel = new ItemUpdateResponseViewModel(item);
            viewModel.UpdateSuccess = success;


            return View("~/Views/Item/AddOrUpdate.cshtml", viewModel);
        }

        /// <summary>
        /// This page should allow the user to create a new item in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View("~/Views/Item/AddOrUpdate.cshtml", new ItemUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(ItemUpdateRequestViewModel requestModel) //Needs a request view model
        {
            var item = new Item();
            requestModel.UpdateItemModel(item);

            bool success = DataManager<Item>.Save(item);

            var viewModel = new ItemUpdateResponseViewModel(item);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Index");
        }
    }
}
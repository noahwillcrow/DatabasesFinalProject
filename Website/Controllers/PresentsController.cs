using DatabaseBridge.Managers;
using DatabaseBridge.Models;
using System.Web.Mvc;
using Website.Models.Request;
using Website.Models.Response;

namespace Website.Controllers
{
    public class HousesController : Controller
    {
        public ActionResult Index()
        {
            var houses = HousesManager.GetAll();
            return View(houses);
        }

        public ActionResult Details(int id)
        {
            var house = HousesManager.GetByID(id);
            if (house == null)
            {
                return RedirectToAction("Index");
            }

            var viewModel = new HouseDetailsViewModel(house);

            return View(viewModel);
        }

        public ActionResult Update(int id)
        {
            var house = HousesManager.GetByID(id);
            var viewModel = new HouseUpdateResponseViewModel(house);
            return View("~/Views/Houses/AddOrUpdate.cshtml", viewModel);
        }

        [HttpPost]
        public ActionResult Update(int id, HouseUpdateRequestViewModel requestModel)
        {
            var house = HousesManager.GetByID(id);
            requestModel.UpdateHouseModel(house);

            bool success = HousesManager.Save(house);

            var viewModel = new HouseUpdateResponseViewModel(house);
            viewModel.UpdateSuccess = success;

            return View("~/Views/Houses/AddOrUpdate.cshtml", viewModel);
        }

        public ActionResult Create()
        {
            return View("~/Views/Houses/AddOrUpdate.cshtml", new HouseUpdateResponseViewModel());
        }

        [HttpPost]
        public ActionResult Create(HouseUpdateRequestViewModel requestModel)
        {
            var house = new House();
            requestModel.UpdateHouseModel(house);

            bool success = HousesManager.Save(house);

            var viewModel = new HouseUpdateResponseViewModel(house);
            viewModel.UpdateSuccess = success;

            return RedirectToAction("Details", new { id = house.ID });
        }
    }
}
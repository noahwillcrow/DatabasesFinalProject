using System.Web.Mvc;

namespace Website.Controllers
{
    public class ReindeerController : Controller
    {
        /// <summary>
        /// This page should simply show a paginated list of reindeer.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index(int page = 1)
        {
            return View();
        }

        /// <summary>
        /// This page should show data on a reindeer, such as its status and a link to its caretaker elf.
        /// </summary>
        /// <param name="reindeerId"></param>
        /// <returns></returns>
        public ActionResult Details(int reindeerId)
        {
            return View();
        }

        /// <summary>
        /// This page should allow the user to edit a reindeer's records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Update(int kidId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(int kidId, bool tempParameterPleaseRemoveThis) //Needs a request view model
        {
            return View();
        }

        /// <summary>
        /// This page should allow the user to create a new reindeer in the records.
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(bool tempParameterPleaseRemoveThis) //Needs a request view model
        {
            return View();
        }
    }
}
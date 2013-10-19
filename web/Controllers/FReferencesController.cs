using BLL.ReferenceBL;
using System.Web.Mvc;

namespace web.Controllers
{
    public class FReferencesController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        //
        // GET: /FReferences/

        public ActionResult Index()
        {
            var references = ReferenceManager.GetReferenceListForFront(lang);
            return View(references);
        }
    }
}

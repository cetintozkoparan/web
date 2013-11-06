using System.Linq;
using System.Web.Mvc;
using web.Models;
using BLL.NewsBL;
using BLL.ReferenceBL;
using BLL.Project;
using BLL.DocumentsBL;
using BLL.PhotoBL;
using BLL.SectorGroupBL;
using BLL.ProductBL;
namespace web.Controllers
{
    public class FHomeController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        
        public ActionResult Index()
        {
            var news = NewsManager.GetNewsListForFront(lang).Take(4);
            var references = ReferenceManager.GetReferenceListForFront(lang);
            var docgroup = DocumentManager.GetDocumentGroupListForFront(lang).First();
            var docs = DocumentManager.GetDocumentListForFront(docgroup.DocumentGroupId).Take(5);
            var projects = ProjectManager.GetProjectListForFront(lang).Take(4);
            var photos = PhotoManager.GetListForFront(lang, 0);
            var sectors = SectorGroupManager.GetSectorGroupListForFront(lang);
            var prods = ProductManager.GetProductListAllForFront(lang);
            ViewBag.docgroupSlug = docgroup.PageSlug;
            ViewBag.docgroupid = docgroup.DocumentGroupId;
            ViewBag.docgroup = docgroup.GroupName;
            HomePageWrapperModel modelbind = new HomePageWrapperModel(prods, sectors, news, references, projects, docs, photos);
            return View(modelbind);
        }

        public ActionResult ChangeCulture(string lang,string returnUrl)
        {
            Session["culture"] = lang;
            if(lang=="en")
                return Redirect("/en/homepage");
            return Redirect("/tr/anasayfa");
        }
    }
}

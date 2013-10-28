using System.Linq;
using System.Web.Mvc;
using web.Models;
using BLL.NewsBL;
using BLL.ReferenceBL;
using BLL.Project;
using BLL.DocumentsBL;
namespace web.Controllers
{
    public class FHomeController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        
        public ActionResult Index()
        {
            var news = NewsManager.GetNewsListForFront(lang);
            var references = ReferenceManager.GetReferenceListForFront(lang);
            var docs = DocumentManager.GetDocumentListForFront(DocumentManager.GetDocumentGroupListForFront(lang).First().DocumentGroupId).Take(5);
            var projects = ProjectManager.GetProjectListForFront(lang).Take(4);
            HomePageWrapperModel modelbind = new HomePageWrapperModel(news, references, projects, docs);
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

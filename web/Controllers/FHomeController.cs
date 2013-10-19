using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using BLL.NewsBL;
using BLL.ReferenceBL;
using DAL;
using DAL.Entities;
namespace web.Controllers
{
    public class FHomeController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        
        public ActionResult Index()
        {
            var news = NewsManager.GetNewsListForFront(lang);
            var references = ReferenceManager.GetReferenceListForFront(lang);
            HomePageWrapperModel modelbind = new HomePageWrapperModel(news, references);
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

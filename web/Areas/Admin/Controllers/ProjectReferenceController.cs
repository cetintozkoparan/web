using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using web.Areas.Admin.Helpers;
using BLL.LanguageBL;
using BLL.ProjectReferenceBL;
using DAL.Entities;
using web.Areas.Admin.Filters;

namespace web.Areas.Admin.Controllers
{
      [AuthenticateUser]
    public class ProjectReferenceController : Controller
    {
        //
        // GET: /Admin/ProjectReference/

        public ActionResult Index()
        {
            string sellang = FillLanguagesList();

            var list = ProjectReferenceManager.GetProjectReferenceList(sellang);
            return View(list);
        }

        public ActionResult AddProjectReference()
        {
            string lang = "";
            if (RouteData.Values["lang"] == null)
                lang = "tr";
            else lang = RouteData.Values["lang"].ToString();

            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language");
            ViewBag.LanguageList = list;
            var groups = ProjectReferenceGroupManager.GetProjectReferenceGroupList(lang);
            var grouplist = new SelectList(groups, "ProjectReferenceGroupId", "GroupName");
            ViewBag.GroupList = grouplist;
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProjectReference(ProjectReferences newmodel, HttpPostedFileBase uploadfile, HttpPostedFileBase uploadimage)
        {
            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language");
            ViewBag.LanguageList = list;
            var groups = ProjectReferenceGroupManager.GetProjectReferenceGroupList(newmodel.Language);
            var grouplist = new SelectList(groups, "ProjectReferenceGroupId", "GroupName", newmodel.ProjectReferenceGroupId);
            ViewBag.GroupList = grouplist;
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(1000, 99999999);
                    uploadfile.SaveAs(Server.MapPath("/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName)));
                    newmodel.ProjectReferenceFile = "/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName);
                }

                if (uploadimage != null && uploadimage.ContentLength > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(1000, 99999999);
                    new ImageHelper(240, 240).SaveThumbnail(uploadimage, "/Content/images/ProjectReferences/", Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadimage.FileName));
                    newmodel.Logo = "/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadimage.FileName);
                }
                else
                {
                    newmodel.Logo = "/Content/images/front/noimage.jpeg";
                }
                newmodel.PageSlug = Utility.SetPagePlug(newmodel.Name);
                newmodel.TimeCreated = DateTime.Now;
                ViewBag.ProcessMessage = ProjectReferenceManager.AddProjectReference(newmodel);
                ModelState.Clear();
                
                return View();
            }
            else
                return View();
        }


        public ActionResult EditProjectReference()
        {
            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language");
            ViewBag.LanguageList = list;
            if (RouteData.Values["id"] != null)
            {
                int nid = 0;
                bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
                if (isnumber)
                {
                    ProjectReferences editrecord = ProjectReferenceManager.GetProjectReferenceById(nid);
                    var pjgroups = ProjectReferenceGroupManager.GetProjectReferenceGroupList(editrecord.Language);
                    var grouplist = new SelectList(pjgroups, "ProjectReferenceGroupId", "GroupName", editrecord.ProjectReferenceGroupId);
                    ViewBag.GroupList = grouplist;
                    return View(editrecord);
                }
                else
                    return View();
            }
            else
                return View();
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProjectReference(ProjectReferences newmodel, HttpPostedFileBase uploadfile, HttpPostedFileBase uploadimage)
        {
            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language");
            ViewBag.LanguageList = list;

            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(1000, 99999999);
                    uploadfile.SaveAs(Server.MapPath("/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName)));
                    newmodel.ProjectReferenceFile = "/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadfile.FileName);
                }

                if (uploadimage != null && uploadimage.ContentLength > 0)
                {
                    Random random = new Random();
                    int rand = random.Next(1000, 99999999);
                    new ImageHelper(240, 240).SaveThumbnail(uploadimage, "/Content/images/ProjectReferences/", Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadimage.FileName));
                    newmodel.Logo = "/Content/images/ProjectReferences/" + Utility.SetPagePlug(newmodel.Name) + "_" + rand + Path.GetExtension(uploadimage.FileName);
                }
                newmodel.PageSlug = Utility.SetPagePlug(newmodel.Name);

                if (RouteData.Values["id"] != null)
                {
                    int nid = 0;
                    bool isnumber = int.TryParse(RouteData.Values["id"].ToString(), out nid);
                    if (isnumber)
                    {
                        newmodel.ProjectReferenceId = nid;
                        ViewBag.ProcessMessage = ProjectReferenceManager.EditProjectReference(newmodel);
                        return View(newmodel);
                    }
                    else
                    {
                        ViewBag.ProcessMessage = false;
                        return View(newmodel);
                    }
                }
                else return View();
            }
            else
                return View();
        }


        string FillLanguagesList()
        {
            string lang = "";
            if (RouteData.Values["lang"] == null)
                lang = "tr";
            else lang = RouteData.Values["lang"].ToString();

            var languages = LanguageManager.GetLanguages();
            var list = new SelectList(languages, "Culture", "Language", lang);
            ViewBag.LanguageList = list;
            return lang;
        }


        public JsonResult EditStatus(int id)
        {
            bool isupdate = ProjectReferenceManager.UpdateStatus(id);
            return Json(isupdate);
        }

        [HttpPost]
        public ActionResult LoadGroup(string lang)
        {
            var grouplst = ProjectReferenceGroupManager.GetProjectReferenceGroupList(lang);
            JsonResult result = Json(new SelectList(grouplst, "ProjectReferenceGroupId", "GroupName"));
            return result;
        }

        public JsonResult Delete(int id)
        {
            bool isdelete = ProjectReferenceManager.Delete(id);
            //if (isdelete)
            return Json(isdelete);
            //  else return false;
        }

        public JsonResult SortRecords(string list)
        {
            JsonList psl = (new JavaScriptSerializer()).Deserialize<JsonList>(list);
            string[] idsList = psl.list;
            bool issorted = ProjectReferenceManager.SortRecords(idsList);
            return Json(issorted);
        }

        public class JsonList
        {
            public string[] list { get; set; }
        }
    }
}

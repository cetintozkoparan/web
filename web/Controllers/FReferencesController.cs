﻿using BLL.PhotoBL;
using BLL.ProjectReferenceBL;
using BLL.ReferenceBL;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using web.Models;

namespace web.Controllers
{
    public class FReferencesController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        //
        // GET: /FReferences/

        public ActionResult Index()
        {
            var groups = ProjectReferenceGroupManager.GetProjectReferenceGroupListForFront(lang);
            List<DAL.Entities.ProjectReferences> references = new List<DAL.Entities.ProjectReferences>();
 
            if (RouteData.Values["gid"] != null)
            {
                references = ProjectReferenceManager.GetProjectReferenceListForFront(Convert.ToInt32(RouteData.Values["gid"].ToString()));
                ViewBag.GroupName = ProjectReferenceGroupManager.GetProjectReferenceGroupById(Convert.ToInt32(RouteData.Values["gid"].ToString())).GroupName;
            }
            else
            {
                references = ProjectReferenceManager.GetProjectReferenceListForFront(lang);
            }

            ProjectReferencesWrapperModel model = new ProjectReferencesWrapperModel(groups,references);
            return View(model);
        }

        public ActionResult Detail(int rid)
        {
            var groups = ProjectReferenceGroupManager.GetProjectReferenceGroupListForFront(lang);
            var reference = ProjectReferenceManager.GetProjectReferenceById(rid);
            var grp = ProjectReferenceGroupManager.GetProjectReferenceGroupById(reference.ProjectReferenceGroupId);
            ViewBag.GroupName = grp.GroupName;
            ViewBag.GroupSlug = grp.PageSlug;
            var photos = PhotoManager.GetList(1, rid);
            ProjectReferencesSubWrapperModel model = new ProjectReferencesSubWrapperModel(groups, reference, photos);
            return View(model);
        }
    }
}

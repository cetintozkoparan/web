﻿using web.Models;
using BLL.ProductBL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.SectorBL;
using BLL.SectorGroupBL;
using DAL.Entities;

namespace web.Controllers
{
    public class FSectorController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

        //
        // GET: /Sector/

        public ActionResult Index()
        {
            var Sector_group_list = SectorGroupManager.GetSectorGroupListForFront(lang);
            Sector Sector = new Sector();
            OurSectors ourSectors = new OurSectors();
            SectorGroup sectorgrp = new SectorGroup();

            if (RouteData.Values["sid"] != null)
            {
                Sector = SectorManager.GetSectorById(Convert.ToInt32(RouteData.Values["sid"].ToString()));
                ViewBag.grpname = SectorGroupManager.GetSectorGroupById(Sector.SectorGroupId).GroupName;
            }
            else if (RouteData.Values["gid"] != null)
            {
                sectorgrp = SectorGroupManager.GetSectorGroupById(Convert.ToInt32(RouteData.Values["gid"].ToString()));
            }
            else
            {
                ourSectors = SectorManager.GetOurSectors(lang);
            }

            SectorWrapperModel swm = new SectorWrapperModel(new List<Sector>(), Sector_group_list, Sector, ourSectors, sectorgrp);
            return View(swm);
        }

        public ActionResult subSectors(int id)
        {
            var sl = SectorManager.GetSectorList(id);

            var sg = SectorGroupManager.GetSectorGroupById(id);
            SectorSubWrapperModel pswm = new SectorSubWrapperModel(sl, sg);
            return PartialView("_Sectors", pswm);
        }

        //public ActionResult ProductDetail(int pid)
        //{
        //    var product_group_list = ProductManager.GetProductGroupListForFront(lang);
            
        //    var product = ProductManager.GetProductById(pid);
        //    var psg = ProductManager.GetProductSubGroupById(product.ProductSubGroupId);
        //    var pg = ProductManager.GetProductGroupById(product.ProductGroupId);

        //    ViewBag.grpid = pg.ProductGroupId;
        //    ViewBag.sgid = psg.ProductSubGroupId;
        //    ViewBag.subgrpname = psg.GroupName;
        //    ViewBag.grpname = pg.GroupName;

        //    ProductDetailWrapperModel model = new ProductDetailWrapperModel(product, product_group_list);
            
        //    return View(model);
        //}
    }
}

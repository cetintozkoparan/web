using web.Models;
using BLL.ProductBL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web.Controllers
{
    public class FProductsController : Controller
    {
        string lang = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();

        //
        // GET: /Urunler/

        public ActionResult Index()
        {
            var product_group_list = ProductManager.GetProductGroupListForFront(lang);
            List<DAL.Entities.Product> product_list = new List<DAL.Entities.Product>();

            if (RouteData.Values["gid"] != null)
            {
                product_list = ProductManager.GetProductListForFront(Convert.ToInt32(RouteData.Values["gid"].ToString()));
                var grp = ProductManager.GetGroupById(Convert.ToInt32(RouteData.Values["gid"].ToString()));
                ViewBag.grpname = grp.GroupName;
            }
            else if (RouteData.Values["sgid"] != null)
            {
                product_list = ProductManager.GetProductListBySubGroupForFront(Convert.ToInt32(RouteData.Values["sgid"].ToString()));
                var subgrp = ProductManager.GetSubGroupById(Convert.ToInt32(RouteData.Values["sgid"].ToString()));
                var grp = ProductManager.GetGroupById(subgrp.ProductGroupId);
                ViewBag.grpid = subgrp.ProductGroupId;
                ViewBag.subgrpname = subgrp.GroupName;
                ViewBag.grpname = grp.GroupName;
            }
            else
            {
                product_list = ProductManager.GetProductListAllForFront(lang);
            }
            
            ProductWrapperModel modelbind = new ProductWrapperModel(product_list, product_group_list);
            return View(modelbind);
        }

        public ActionResult subproductgroups(int id)
        {
            var psg = ProductManager.GetProductSubGroupListForFront(lang, id);
            var pg = ProductManager.GetProductGroupById(id);
            ProductSubWrapperModel pswm = new ProductSubWrapperModel(psg, pg);
            return PartialView("_subproductgroups", pswm);
        }

        //public ActionResult ProductList(int gid)
        //{
        //    var product_group_list = ProductManager.GetProductGroupListForFront(lang);
        //    var product_list = ProductManager.GetProductList(gid);
        //    ProductWrapperModel modelbind = new ProductWrapperModel(product_list, product_group_list);
        //    return View(modelbind);
        //}

        public ActionResult ProductDetail(int pid)
        {
            var product_group_list = ProductManager.GetProductGroupListForFront(lang);
            
            var product = ProductManager.GetProductById(pid);
            var psg = ProductManager.GetProductSubGroupById(product.ProductSubGroupId);
            var pg = ProductManager.GetProductGroupById(product.ProductGroupId);

            ViewBag.grpid = pg.ProductGroupId;
            ViewBag.sgid = psg.ProductSubGroupId;
            ViewBag.subgrpname = psg.GroupName;
            ViewBag.grpname = pg.GroupName;

            ProductDetailWrapperModel model = new ProductDetailWrapperModel(product, product_group_list);
            
            return View(model);
        }

        [HttpPost]
        public string AddToList(string id)
        {
            if (!this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("OfferList"))
            {
                HttpCookie cookie = new HttpCookie("OfferList");
                cookie.Value = "[{id:'" + id + "'}]";
                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return "1";
            }
            else
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["OfferList"];
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(cookie.Value);
                cookie.Value = "[";

                foreach (var element in values)
                {
                    foreach (var entry in element)
                    {
                        if (entry.Value == id)
                            return values.Count().ToString();

                        cookie.Value += "{id:'" + entry.Value + "'},";
                    }
                }

                cookie.Value += "{id:'" + id + "'}]";

                this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                return (values.Count() + 1).ToString();
            }
        }

        [HttpPost]
        public string RemoveFromList(string id)
        {
            HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies["OfferList"];
            var values = JsonConvert.DeserializeObject<Dictionary<string, string>[]>(cookie.Value);
            cookie.Value = "[";

            foreach (var element in values)
            {
                foreach (var entry in element)
                {
                    if (entry.Value == id)
                        continue;

                    cookie.Value += "{id:'" + entry.Value + "'},";
                }
            }
            if (cookie.Value.Equals("["))
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
            }
            else
            {
                cookie.Value = cookie.Value.Substring(0, cookie.Value.Length-1) + "]";
            }

            this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);

            return (values.Count() - 1).ToString();
        }

    }
}

using System.Web.Mvc;

namespace web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("loginpagex", "yonetim/login_eski", new { action = "Login", Controller = "Account" });
            context.MapRoute("loginpagex_v2", "yonetim/login", new { action = "Login_v2", Controller = "Account" });
            context.MapRoute("logoutx", "cikis", new { action = "Logout", Controller = "Account" });
            context.MapRoute("homepage_defaultx", "yonetim", new { action = "Index", Controller = "Home" });
            context.MapRoute("homepagex", "yonetim/anasayfa", new { action = "Index", Controller = "Home" });
            //context.MapRoute("homepage_prm", "yonetim/{type}", new { action = "Index", Controller = "Home" });
            //context.MapRoute("homepage_all", "yonetim/teklif/tumteklifler", new { action = "AllList", Controller = "Home" });
            //context.MapRoute("homepage_detail", "yonetim/teklifdetay/{id}", new { action = "Details", Controller = "Home" });
            context.MapRoute("instituional_indexx", "yonetim/kurumsal", new { action = "Index", Controller = "Institutional" });
            context.MapRoute("instituional_mision_defaultx", "yonetim/kurumsal/misyon", new { action = "Misyon", Controller = "Institutional" });
            context.MapRoute("instituional_vision_defaultx", "yonetim/kurumsal/hakkimizda", new { action = "Vizyon", Controller = "Institutional" });
            context.MapRoute("instituional_visionx", "yonetim/kurumsal/hakkimizda/{lang}", new { action = "Vizyon", Controller = "Institutional" });
            context.MapRoute("instituional_misionx", "yonetim/kurumsal/misyon/{lang}", new { action = "Misyon", Controller = "Institutional" });

            //HABERLER
            context.MapRoute("news_defaultx", "yonetim/haberler", new { action = "Index", Controller = "News" }, null, new[] { "web.Areas.Admin.Controllers" });
            context.MapRoute("newsx", "yonetim/haberler/{lang}", new { action = "Index", Controller = "News" });
            context.MapRoute("newsaddx", "yonetim/haberekle", new { action = "AddNews", Controller = "News" });
            context.MapRoute("newseditx", "yonetim/haberduzenle/{id}", new { action = "EditNews", Controller = "News" });

            //PROJECTS
            context.MapRoute("project_defaultx", "yonetim/projeler", new { action = "Index", Controller = "Project" });
            context.MapRoute("projectx", "yonetim/projeler/{lang}", new { action = "Index", Controller = "Project" });
            context.MapRoute("projectaddx", "yonetim/projeekle", new { action = "AddProject", Controller = "Project" });
            context.MapRoute("projecteditx", "yonetim/projeduzenle/{id}", new { action = "EditProject", Controller = "Project" });


            //TEKLİFLER
         //   context.MapRoute("teklif_default", "yonetim/tumteklifler", new { action = "Index", Controller = "Teklif" });
            context.MapRoute("teklifx", "yonetim/teklifler/{type}", new { action = "Index", Controller = "Teklif" });
            context.MapRoute("teklif_detailx", "yonetim/teklifler/detay/{id}", new { action = "Details", Controller = "Teklif" });
            context.MapRoute("teklif_silx", "yonetim/teklifler/sil/{id}/{type}", new { action = "Delete", Controller = "Teklif" });
           
            //LİnKLER
            context.MapRoute("link_defaultx", "yonetim/linkler", new { action = "Index", Controller = "Link" });
            context.MapRoute("linkaddx", "yonetim/linkekle", new { action = "AddLink", Controller = "Link" });
            context.MapRoute("linkeditx", "yonetim/linkduzenle/{id}", new { action = "EditLink", Controller = "Link" });
            context.MapRoute("linksx", "yonetim/linkler/{lang}", new { action = "Index", Controller = "Link" });


            //REFERANSLAR
            context.MapRoute("references_defaultx", "yonetim/referanslar", new { action = "Index", Controller = "Reference" });
            context.MapRoute("referencesx", "yonetim/referanslar/{lang}", new { action = "Index", Controller = "Reference" });
            context.MapRoute("referenceaddx", "yonetim/referansekle", new { action = "AddReference", Controller = "Reference" });
            context.MapRoute("referenceeditx", "yonetim/referansduzenle/{id}", new { action = "EditReference", Controller = "Reference" });

            //IS ORTAKLARI
            context.MapRoute("solutionpartner_defaultx", "yonetim/cozumortaklari", new { action = "Index", Controller = "SolutionPartner" });
            context.MapRoute("solutionpartnerx", "yonetim/cozumortaklari/{lang}", new { action = "Index", Controller = "SolutionPartner" });
            context.MapRoute("solutionpartneraddx", "yonetim/cozumortagiekle", new { action = "AddSolutionPartner", Controller = "SolutionPartner" });
            context.MapRoute("solutionpartnereditx", "yonetim/cozumortagiduzenle/{id}", new { action = "EditSolutionPartner", Controller = "SolutionPartner" });

            //IS ORTAKLARI
            context.MapRoute("certificate_defaultx", "yonetim/sertifikalar", new { action = "Index", Controller = "Certificate" });
            context.MapRoute("certificatex", "yonetim/sertifikalar/{lang}", new { action = "Index", Controller = "Certificate" });
            context.MapRoute("certificateaddx", "yonetim/sertifikaekle", new { action = "AddCertificate", Controller = "Certificate" });
            context.MapRoute("certificateeditx", "yonetim/sertifikaduzenle/{id}", new { action = "EditCertificate", Controller = "Certificate" });

            //MAİL KULLANICILARI
            context.MapRoute("mailuser_defx", "yonetim/mailkullanicilari", new { action = "Index", Controller = "Mail" });
            context.MapRoute("mailuserx", "yonetim/mailkullanicilari/{type}", new { action = "Index", Controller = "Mail" });
            context.MapRoute("mailuser_addx", "yonetim/ekle", new { action = "Add", Controller = "Mail" });
            context.MapRoute("mailuser_editx", "yonetim/duzenle/{id}", new { action = "Edit", Controller = "Mail" });
            context.MapRoute("mail_settingx", "yonetim/mailayarlari", new { action = "MailSetting", Controller = "Mail" });


            //DÖKÜMANLAR
            context.MapRoute("documentsx", "yonetim/dokumanlar", new { action = "Index", Controller = "Documents" });
            context.MapRoute("documentsgroups_defaultx", "yonetim/dokumangruplari", new { action = "Index", Controller = "DocumentGroup" });
            context.MapRoute("documentsgroupsx", "yonetim/dokumangruplari/{lang}", new { action = "Index", Controller = "DocumentGroup" });
            context.MapRoute("adddocumentx", "yonetim/dokumanekle", new { action = "AddDocument", Controller = "Documents" });
            context.MapRoute("editdocumentx", "yonetim/dokumanduzenle/{id}", new { action = "EditDocument", Controller = "Documents" });
            context.MapRoute("documentlist_defaultx", "yonetim/dokumanlistesi", new { action = "Index", Controller = "Documents" }, null, new[] { "web.Areas.Admin.Controllers" });
            context.MapRoute("documentlistx", "yonetim/dokumanlistesi/{lang}", new { action = "Index", Controller = "Documents" });
            context.MapRoute("documentlist_twoparamx", "yonetim/dokumanlistesi/{lang}/{id}", new { action = "Index", Controller = "Documents" });


            //ÜRÜNLER
            context.MapRoute("productsx", "yonetim/urunler", new { action = "Index", Controller = "Product" });
            context.MapRoute("productsgroups_defaultx", "yonetim/urungruplari", new { action = "Index", Controller = "ProductGroup" });
            context.MapRoute("productsgroups_editx", "yonetim/urungrubuduzenle/{id}", new { action = "EdtiGroup", Controller = "ProductGroup" });
            context.MapRoute("productsgroupsx", "yonetim/urungruplari/{lang}", new { action = "Index", Controller = "ProductGroup" });
            context.MapRoute("addproductsx", "yonetim/urunekle", new { action = "AddProduct", Controller = "Product" });
            context.MapRoute("editproductsx", "yonetim/urunduzenle/{id}", new { action = "EditProduct", Controller = "Product" });
            context.MapRoute("productslist_defaultx", "yonetim/urunlistesi", new { action = "Index", Controller = "Product" }, null, new[] { "web.Areas.Admin.Controllers" });
            context.MapRoute("productslistx", "yonetim/urunlistesi/{lang}", new { action = "Index", Controller = "Product" });
            context.MapRoute("productslist_twoparamx", "yonetim/urunlistesi/{lang}/{id}", new { action = "Index", Controller = "Product" });

            //RESİM GALERİ
            context.MapRoute("gallerygroupx", "yonetim/galeriler", new { action = "Index", Controller = "Gallery" });
            context.MapRoute("gallerygroups_defaultx", "yonetim/galerigruplari", new { action = "Index", Controller = "GalleryGroup" });
            context.MapRoute("gallerygroupsx", "yonetim/galerigruplari/{lang}", new { action = "Index", Controller = "GalleryGroup" });
            context.MapRoute("galleryimageaddx", "yonetim/resimekle", new { action = "AddImage", Controller = "Gallery" });
            context.MapRoute("gallerylistx", "yonetim/galeriresimleri", new { action = "GalleryList", Controller = "Gallery" });


            //BANKA BİLGİLERİ
            context.MapRoute("bank_defaultx", "yonetim/bankabilgileri", new { action = "Index", Controller = "Bank" });
            context.MapRoute("bankx", "yonetim/bankabilgileri/{lang}", new { action = "Index", Controller = "Bank" });
            context.MapRoute("bankaddx", "yonetim/bankabilgisiekle", new { action = "AddBank", Controller = "Bank" });
            context.MapRoute("bankeditx", "yonetim/bankabilgisiduzenle/{id}", new { action = "EditBank", Controller = "Bank" });

            // İLETİŞİM

            context.MapRoute("contact_defaultx", "yonetim/iletisim", new { action = "Index", Controller = "Contact" });
            context.MapRoute("contactx", "yonetim/iletisim/{lang}", new { action = "Index", Controller = "Contact" });

            // İNSAN KAYNAKLARI
            context.MapRoute("ik_indexx", "yonetim/insankaynaklari", new { action = "Index", Controller = "HumanResource" });
            context.MapRoute("ik_positionsx", "yonetim/insankaynaklari/pozisyonlar", new { action = "HumanResourcePositions", Controller = "HumanResource" });
            context.MapRoute("ik_positionaddx", "yonetim/insankaynaklari/pozisyonekle", new { action = "AddHumanResourcePosition", Controller = "HumanResource" });
            context.MapRoute("ik_positioneditx", "yonetim/insankaynaklari/pozisyonduzenle/{id}", new { action = "EditHumanResourcePosition", Controller = "HumanResource" });

            context.MapRoute("songuncellemeler", "yonetim/songuncellemeler", new { action = "Index", Controller = "Updates" });

            context.MapRoute(
                "Admin_defaultx",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

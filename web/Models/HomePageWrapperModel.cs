using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Entities;

namespace web.Models
{
    public class HomePageWrapperModel
    {
        public IEnumerable<News> news { get; set; }
        public IEnumerable<References> references { get; set; }
        public IEnumerable<Projects> projects { get; set; }
        public IEnumerable<Document> docs { get; set; }

        public HomePageWrapperModel(IEnumerable<News> news, IEnumerable<References> references, IEnumerable<Projects> projects, IEnumerable<Document> docs)
        {
            this.news = news;
            this.references = references;
            this.projects = projects;
            this.docs = docs;
        }
    }
}
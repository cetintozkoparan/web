using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class ProductSubWrapperModel
    {
        //public IEnumerable<Product> products { get; set; }
        public ProductGroup productgroup { get; set; }
        public IEnumerable<ProductSubGroup> productsubgroups { get; set; }

        public ProductSubWrapperModel(IEnumerable<ProductSubGroup> productsubgroups, ProductGroup productgroup)
        {
            this.productsubgroups = productsubgroups;
            this.productgroup = productgroup;
            //this.productsubgroups = productsubgroups;
        }
    }
}
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class ProductDetailWrapperModel
    {
        //public IEnumerable<Product> products { get; set; }
        public Product product { get; set; }
        public IEnumerable<ProductGroup> productgroups { get; set; }

        public ProductDetailWrapperModel(Product product, IEnumerable<ProductGroup> productgroups)
        {
            this.product = product;
            this.productgroups = productgroups;
            //this.productsubgroups = productsubgroups;
        }
    }
}
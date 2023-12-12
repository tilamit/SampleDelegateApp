using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDelegateApp
{
    public class ProductList
    {
        //Delegate declared or signature
        public delegate string GetCostWiseProducts(List<Product> productLst);

        Product p1 = new Product() { Name = "Photo Frame", Price = 40 };
        Product p2 = new Product() { Name = "Desktop", Price = 200 };
        Product p3 = new Product() { Name = "Pen", Price = 8 };

        StringBuilder str = null;

        public string GetLessCostly(List<Product> productLst)
        {
            productLst.Add(p3);
            int products = productLst.Where(c => c.Price <= 10).Count();

            str = new StringBuilder();
            str.Append("Total less costly products");
            str.Append(products);

            return str.ToString();
        }

        public string GetCostly(List<Product> productLst)
        {
            productLst.Add(p1);
            int products = productLst.Where( c=> c.Price > 10 && c.Price < 100).Count();

            str = new StringBuilder();
            str.Append("Total costly products");
            str.Append(products);

            return str.ToString();
        }

        public string GetTooCostly(List<Product> productLst)
        {
            productLst.Add(p2);
            int products = productLst.Where(c => c.Price >= 100).Count();

            str = new StringBuilder();
            str.Append("Total too costly products ");
            str.Append(products);

            return str.ToString();
        }
    }
}

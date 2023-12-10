using System;
using System.Collections.Generic;
using static SampleDelegateApp.ProductList;

namespace SampleDelegateApp
{
    internal class Program
    {
        //Delegate declared or signature
        public delegate bool FilterDelegate(Product p);

        static void Main(string[] args)
        {
            //Delegate part - Starts
            Product p1 = new Product() { Name = "Jacket", Price = 20 };
            Product p2 = new Product() { Name = "Pant", Price = 15 };
            Product p3 = new Product() { Name = "Smart Watch", Price = 12 };
            Product p4 = new Product() { Name = "Laptop Bag", Price = 100 };
            Product p5 = new Product() { Name = "Glasses", Price = 10 };
            Product p6 = new Product() { Name = "Laptop Mouse", Price = 8 };

            List<Product> product = new List<Product>() { p1, p2, p3, p4, p5, p6 };

            //Invoke ShowProducts using appropriate delegate
            //ShowProducts("Less Costly:", product, IsLessCostly);
            //ShowProducts("Costly:", product, IsCostly);
            //ShowProducts("Too Costly:", product, IsTooCostly);

            //Multicast delegate
            ProductList productList = new ProductList();

            GetCostWiseProducts productLst = null;
            
            productLst += new GetCostWiseProducts(productList.GetLessCostly);
            productLst += new GetCostWiseProducts(productList.GetCostly);
            productLst += new GetCostWiseProducts(productList.GetTooCostly);

            foreach (GetCostWiseProducts item in productLst.GetInvocationList())
            {
                var result = item(product);
                Console.WriteLine(result);

                Console.WriteLine("\n");
            }

            Console.Read();
            //Delegate part - Ends
        }

        /// <summary>
        /// A method to filter out the products
        /// </summary>
        /// <param name="product">A list of product</param>
        /// <param name="filter">A filter</param>
        /// <returns>A filtered list</returns>
        static void ShowProducts(string customText, List<Product> product, FilterDelegate filter)
        {
            Console.WriteLine(customText);

            foreach (Product p in product)
            {
                if (filter(p))
                {
                    Console.WriteLine(p.Name + " costs " + p.Price);
                }
            }

            Console.Write("\n");
        }

        //Filters start
        static bool IsLessCostly(Product p)
        {
            return p.Price <= 10;
        }

        static bool IsCostly(Product p)
        {
            return p.Price > 10 && p.Price < 100;
        }

        static bool IsTooCostly(Product p)
        {
            return p.Price >= 100;
        }
        //Filters end
    }
}

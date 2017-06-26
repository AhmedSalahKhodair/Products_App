using ProductApps.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProductApps.Models
{
    public class ProductDBIntializer : DropCreateDatabaseAlways<ProductContext>
    {

        protected override void Seed(ProductContext context)
        {
            context.products.Add(new Product()
            {
                ProductName = "Mouse",
                Price = 50,
                Description = "Yello black wireless mouse"
            });

            context.products.Add(new Product()
            {
                ProductName = "Car",
                Price = 10000000,
                Description = "Black Audi 2018 Model Car"
            });

            context.products.Add(new Product()
            {
                ProductName = "Plane",
                Price = 100000000,
                Description = "F16 Rocket"
            });


            base.Seed(context);
        }


    }
}
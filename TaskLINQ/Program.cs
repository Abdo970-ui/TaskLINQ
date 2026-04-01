using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Numerics;
using TaskLINQ.Data;
using TaskLINQ.Models;

namespace TaskLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            //1-List all customers' first and last names along with their email addresses.
            var customers = _context.Customers.AsQueryable();
            foreach (var item in customers)
            {
                Console.WriteLine($"{item.FirstName} , {item.LastName} , {item.Email}");
            }



            //2- Retrieve all orders processed by a specific staff member (e.g., staff_id = 3).
            var orders = _context.Orders.Where(o => o.OrderId == 3).Select(o => new
            {
                o.OrderId,
                o.OrderDate,

            });
            foreach (var item in orders)
            {

                Console.WriteLine($"{item.OrderId} , {item.OrderDate}");

            }


            //3- Get all products that belong to a category named "Mountain Bikes".
            var products = _context.Products.Where(p => p.Category.CategoryName == "Mountain Bikes");

            foreach (var product in products)
            {
                Console.WriteLine(product.ProductName);
            }

            //4-Count the total number of orders per store.

            var OrdersGroups = _context.Orders
            .GroupBy(o => o.StoreId)
            .Select(g => new
            {
                StoreId = g.Key,
                OrdersCount = g.Count()
            });

            foreach (var item in OrdersGroups)
            {
                Console.WriteLine($"{item.StoreId} , {item.OrdersCount}");
            }

            //5- List all orders that have not been shipped yet (shipped_date is null).

            var orders = _context.Orders
           .Where(o => o.ShippedDate == null);

            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.OrderId}");
            }


            // 6 - Display each customer’s full name and the number of orders they have placed.

            var result = _context.Customers
              .Select(c => new
              {
                  FullName = c.FirstName + " " + c.LastName,
                  OrdersCount = c.Orders.Count()
              });

            foreach (var item in result)
            {
                Console.WriteLine($"{item.FullName} - Orders: {item.OrdersCount}");
            }


            //7- List all products that have never been ordered (not found in order_items).
            var products = _context.Products.Where(p => !p.OrderItems.Any());
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }


            //8- Display products that have a quantity of less than 5 in any store stock.
            var products = _context.Products.Where(p => p.Stocks.Any(s => s.Quantity < 5))
                .Select(p => p.ProductName);
            foreach (var item in products)
            {
                Console.WriteLine(item);
            }

            //9- Retrieve the first product from the products table.
            var product = _context.Products.FirstOrDefault();

            if (product != null)
            {
                Console.WriteLine(product.ProductName);
            }

            //10- Retrieve all products from the products table with a certain model year.

            var products = _context.Products.Where(p => p.ModelYear == 2019);
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }


            //11- Display each product with the number of times it was ordered.

            var ProductWithNumberorder = _context.Products
           .Select(p => new
           {
               ProductName = p.ProductName,
               OrdersCount = p.OrderItems.Count()
           });

            foreach (var item in ProductWithNumberorder)
            {
                Console.WriteLine($"{item.ProductName} - Ordered: {item.OrdersCount}");
            }

            //12- Count the number of products in a specific category.

            var count = _context.Products
            .Count(p => p.Category.CategoryName == "Children Bicycles");

            Console.WriteLine(count);

            //13- Calculate the average list price of products.
            var avgprice = _context.Products.Average(p => p.ListPrice);
            {
                Console.WriteLine(avgprice);
            }

            //14- Retrieve a specific product from the products table by ID.

            var product = _context.Products.FirstOrDefault();
            if (product != null)
            {
                Console.WriteLine(product.ProductName);

            }

            //15- List all products that were ordered with a quantity greater than 3 in any order.
            var products = _context.Products
             .Where(p => p.OrderItems.Any(o => o.Quantity > 3));

            foreach (var item in products)
            {
                Console.WriteLine(item.ProductName);
            }

            //16- Display each staff member’s name and how many orders they processed.
            var result = _context.Staffs
                .Select(s => new
                {
                    FullName = s.FirstName + " " + s.LastName,
                    OrdersCount = s.Orders.Count(),
                });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.FullName} , {item.OrdersCount}");
            }

            //17- List active staff members only (active = true) along with their phone numbers.
            var staff = _context.Staffs
           .Where(s => s.Active == 1)
            .Select(s => new
            {
                Name = s.FirstName + " " + s.LastName,
                s.Phone
            });

            foreach (var s in staff)
            {
                Console.WriteLine($"{s.Name} - {s.Phone}");
            }


            //18- List all products with their brand name and category name.
            var products = _context.Products
                .Select(p => new
                {
                    p.ProductName,
                    BrandName = p.Brand.BrandName,
                    CategoryName = p.Category.CategoryName
                });
            foreach (var item in products)
            {
                Console.WriteLine($"{item.ProductName} , {item.BrandName} , {item.CategoryName}");
            }


            //19- Retrieve orders that are completed.
            var orders = _context.Orders
           .Where(o => o.OrderStatus == 4);

            foreach (var o in orders)
            {
                Console.WriteLine(o.OrderId);
            }
            //20- List each product with the total quantity sold (sum of quantity from order_items).

            var result = _context.OrderItems
            .GroupBy(oi => oi.Product)
             .Select(g => new
             {
                 ProductName = g.Key.ProductName,
                 TotalSold = g.Sum(x => x.Quantity)
             });
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProductName} - {item.TotalSold}");
            }

        }
    }
}

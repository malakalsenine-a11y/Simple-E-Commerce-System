using System;
using System.Collections.Generic;

namespace project01
{
    class Product
    {
        public int Id;
        public string Name;
        public double Price;
        public int Quantity;
    }

    internal class Program
    {
        static List<Product> products = new List<Product>();
        static List<Product> cart = new List<Product>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Product");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Add to Cart");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Checkout");
                Console.WriteLine("7. Exit");

                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (choice)
                {
                    case 1: AddProduct(); break;
                    case 2: ViewProducts(); break;

                    case 3:
                        Console.Write("Search by (1: Id, 2: Name): ");
                        int type = int.Parse(Console.ReadLine());

                        if (type == 1)
                        {
                            int id = int.Parse(Console.ReadLine());
                            var p = SearchProduct(id);
                            Console.WriteLine(p != null ? p.Name : "Not found");
                        }
                        else
                        {
                            string name = Console.ReadLine();
                            var p = SearchProduct(name);
                            Console.WriteLine(p != null ? p.Name : "Not found");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Id: ");
                        int idd = int.Parse(Console.ReadLine());
                        Console.Write("Enter Qty: ");
                        int qty = int.Parse(Console.ReadLine());
                        AddToCart(idd, qty);
                        break;

                    case 5: ViewCart(); break;
                    case 6: Checkout(); break;
                    case 7: return;
                }
            }
        }

        static void AddProduct()
        {
            Product p = new Product();

            Console.Write("Id: ");
            p.Id = int.Parse(Console.ReadLine());

            Console.Write("Name: ");
            p.Name = Console.ReadLine();

            Console.Write("Price: ");
            p.Price = double.Parse(Console.ReadLine());

            Console.Write("Quantity: ");
            p.Quantity = int.Parse(Console.ReadLine());

            products.Add(p);
        }

        static void ViewProducts()
        {
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Qty: {p.Quantity}");
            }
        }

        static Product SearchProduct(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id) return p;
            }
            return null;
        }

        static Product SearchProduct(string name)
        {
            foreach (var p in products)
            {
                if (p.Name == name) return p;
            }
            return null;
        }

        static void AddToCart(int productId, int quantity)
        {
            Product p = SearchProduct(productId);

            if (p == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            if (p.Quantity < quantity)
            {
                Console.WriteLine("Not enough quantity!");
                return;
            }

            UpdateQuantity(ref p.Quantity, quantity);

            cart.Add(new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = quantity
            });
        }

        static void UpdateQuantity(ref int stock, int qty)
        {
            stock -= qty;
        }

        static void ViewCartRecursive(int index)
        {
            if (index >= cart.Count) return;

            var item = cart[index];
            Console.WriteLine($"Name: {item.Name}, Qty: {item.Quantity}");

            ViewCartRecursive(index + 1);
        }

        static void ViewCart()
        {
            ViewCartRecursive(0);
        }

        static void Checkout()
        {
            double total = 0;

            foreach (var item in cart)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine($"Total Price: {total}");
            cart.Clear();
        }
    }
}
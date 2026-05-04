using System;
using System.Collections.Generic;

namespace project01
{
    // Represents a product in the system
    class Product
    {
        public int Id;        // Product ID
        public string Name;   // Product name
        public double Price;  // Product price
        public int Quantity;  // Available quantity in stock
    }

    internal class Program
    {
        // List to store all products
        static List<Product> products = new List<Product>();

        // List to store cart items
        static List<Product> cart = new List<Product>();

        static void Main(string[] args)
        {
            // Infinite loop to keep the program running
            while (true)
            {
                // Display menu options
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Product");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Add to Cart");
                Console.WriteLine("5. View Cart");
                Console.WriteLine("6. Checkout");
                Console.WriteLine("7. Exit");

                int choice;

                // Handle invalid input using try-catch
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid input!");
                    continue; // Restart loop if input is invalid
                }

                // Execute selected option
                switch (choice)
                {
                    case 1:
                        AddProduct();
                        break;

                    case 2:
                        ViewProducts();
                        break;

                    case 3:
                        Console.Write("Search by (1: Id, 2: Name): ");
                        int type = int.Parse(Console.ReadLine());

                        if (type == 1)
                        {
                            Console.Write("Enter Id: ");
                            int id = int.Parse(Console.ReadLine());

                            var p = SearchProduct(id);

                            // Check if product found
                            if (p != null)
                                Console.WriteLine($"Found: {p.Name}");
                            else
                                Console.WriteLine("Product not found");
                        }
                        else
                        {
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();

                            var p = SearchProduct(name);

                            if (p != null)
                                Console.WriteLine($"Found: {p.Name}");
                            else
                                Console.WriteLine("Product not found");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Product Id: ");
                        int idd = int.Parse(Console.ReadLine());

                        Console.Write("Enter Quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        AddToCart(idd, qty);
                        break;

                    case 5:
                        ViewCart();
                        break;

                    case 6:
                        Checkout();
                        break;

                    case 7:
                        return; // Exit the program
                }
            }
        }

        // Adds a new product to the product list
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

            products.Add(p); // Add product to list
        }

        // Displays all products
        static void ViewProducts()
        {
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Qty: {p.Quantity}");
            }
        }

        // Search product by ID (Method Overloading)
        static Product SearchProduct(int id)
        {
            foreach (var p in products)
            {
                if (p.Id == id)
                    return p;
            }
            return null; // Return null if not found
        }

        // Search product by Name (Method Overloading)
        static Product SearchProduct(string name)
        {
            foreach (var p in products)
            {
                if (p.Name == name)
                    return p;
            }
            return null;
        }

        // Adds a product to the cart
        static void AddToCart(int productId, int quantity)
        {
            Product p = SearchProduct(productId);

            // Check if product exists
            if (p == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            // Check if enough quantity is available
            if (p.Quantity < quantity)
            {
                Console.WriteLine("Not enough quantity!");
                return;
            }

            // Update stock using ref keyword
            UpdateQuantity(ref p.Quantity, quantity);

            // Add a copy of the product to the cart
            cart.Add(new Product
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = quantity
            });

            Console.WriteLine("Added to cart!");
        }

        // Updates product quantity using ref
        static void UpdateQuantity(ref int stock, int qty)
        {
            stock -= qty;
        }

        // Recursive function to display cart items
        static void ViewCartRecursive(int index)
        {
            // Base case: stop when index reaches end
            if (index >= cart.Count)
                return;

            var item = cart[index];

            Console.WriteLine($"Name: {item.Name}, Qty: {item.Quantity}");

            // Recursive call
            ViewCartRecursive(index + 1);
        }

        // Starts recursive cart display
        static void ViewCart()
        {
            ViewCartRecursive(0);
        }

        // Calculates total price and clears the cart
        static void Checkout()
        {
            double total = 0;

            foreach (var item in cart)
            {
                total += item.Price * item.Quantity;
            }

            Console.WriteLine($"Total Price: {total}");

            cart.Clear(); // Empty cart after checkout
        }
    }
}
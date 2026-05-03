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
        List<Product> products = new List<Product> ();
        List<Product> cart = new List<Product> ();

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

                int choice = int .Parse (Console.ReadLine());

                switch (choice)
                {
                    case 1: AddProduct(); break;
                    case 2: ViewProducts(); break;
                    case 3: /* Search */ break;
                    case 4: /* Add to cart */ break;
                    case 5: ViewCart(); break;
                    case 6: Checkout(); break;
                    case 7: return;
                }


                //Methods

                //1- AddProduct() 
                void AddProduct()
                {
                    Product p = new Product();

                    Console.Write("Enter Id: ");
                    p.Id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    p.Name = Console.ReadLine();

                    Console.Write("Enter Price: ");
                    p.Price = double.Parse(Console.ReadLine());

                    Console.Write("Enter Quantity: ");
                    p.Quantity = int.Parse(Console.ReadLine());

                    products.Add(p);
                }

                //2- ViewProducts()

                void ViewProducts()
                {
                    foreach (var p in products)
                    {
                        Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Price: {p.Price}, Qty: {p.Quantity}");
                    }
                }


            }
        }
    }
}

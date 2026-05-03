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
            Console.WriteLine("Hello, World!");
        }
    }
}

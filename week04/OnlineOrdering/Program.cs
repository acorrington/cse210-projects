using System;

class Program
{
    static void Main(string[] args)
    {
        // Example of creating an order with a customer in the USA
        Customer customer = new Customer("John Doe", new Address("123 Main St", "Springfield", "IL", "USA"));
        List<Product> products = new List<Product>
        {
            new Product(1, "Laptop", 999.99, 1),
            new Product(2, "Mouse", 25.50, 2),
            new Product(3, "Keyboard", 45.00, 1)
        };
        Order order = new Order(customer, products);
        Console.WriteLine("Order Total: $" + order.GetTotal());
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());

        // Example of creating an order with a customer outside the USA
        Customer internationalCustomer = new Customer("Jane Smith", new Address("456 Elm St", "Toronto", "ON", "Canada"));
        List<Product> internationalProducts = new List<Product>
        {
            new Product(4, "Smartphone", 699.99, 1),
            new Product(5, "Charger", 19.99, 2)
        };
        Order internationalOrder = new Order(internationalCustomer, internationalProducts);
        Console.WriteLine("International Order Total: $" + internationalOrder.GetTotal());
        Console.WriteLine(internationalOrder.GetPackingLabel());
        Console.WriteLine(internationalOrder.GetShippingLabel());
    }
}
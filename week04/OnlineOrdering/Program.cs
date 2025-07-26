using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        Address address1 = new Address("1995 E Javelina St", "Gilbert", "AZ", "USA");
        Address address2 = new Address("123 Maple Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("3233 E Siggard Dr", "Kailua", "HI", "USA");

        Customer customer1 = new Customer("Abram Holmgren", address1);
        Customer customer2 = new Customer("Finnley Daniel", address2);
        Customer customer3 = new Customer("Peter Clayton", address3);

        Product product1 = new Product("Lego Castle", 100100, 499.98, 1);
        Product product2 = new Product("Lego MiniFig", 100200, 9.58, 3);
        Product product3 = new Product("Lego Car", 100300, 349.98, 1);
        Product product4 = new Product("Lego Robot", 100400, 99.98, 2);
        Product product5 = new Product("Lego Flowers", 100500, 25.98, 3);
        Product product6 = new Product("Lego Tower", 100600, 599.98, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product2);
        order1.AddProduct(product6);
        order1.AddProduct(product4);
        order1.AddProduct(product1);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product1);
        order2.AddProduct(product6);

        Order order3 = new Order(customer3);
        order3.AddProduct(product3);
        order3.AddProduct(product4);
        order3.AddProduct(product5);

        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
        DisplayOrderDetails(order3);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("*********************************************");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"Total Price: ${order.CalculateTotalCost():0.00}");
        Console.WriteLine("*********************************************\n");
    }
}
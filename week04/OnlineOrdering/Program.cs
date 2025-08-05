using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Anytown", "NY", "USA");
        Customer customer1 = new Customer("Alice", address1);
        List<Product> products1 = new List<Product>
        {
            new Product("Widget", 1001, 3.5, 4),
            new Product("Gadget", 1002, 5.0, 2)
        };
        Order order1 = new Order(products1, customer1);

        Address address2 = new Address("456 Elm St", "Othertown", "ON", "Canada");
        Customer customer2 = new Customer("Bob", address2);
        List<Product> products2 = new List<Product>
        {
            new Product("Thingamajig", 2001, 10.0, 1),
            new Product("Doohickey", 2002, 2.5, 3),
            new Product("Whatsit", 2003, 7.5, 2)
        };
        Order order2 = new Order(products2, customer2);

        List<Order> orders = new List<Order> { order1, order2 };

        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine("Total Price: $" + order.CalculateTotalCost());
            Console.WriteLine();
        }
    }
}

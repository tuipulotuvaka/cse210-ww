using System;

class Program
{
    static void Main(string[] args)
    {
        // ORDER 1 - USA CUSTOMER

        Address address1 = new Address(
            "123 Main Street",
            "Salt Lake City",
            "Utah",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Product product1 = new Product(
            "Laptop",
            "L1001",
            899.99,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "M1002",
            29.99,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "K1003",
            49.99,
            1
        );

        Order order1 = new Order(customer1);

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // ORDER 2 - INTERNATIONAL CUSTOMER

        Address address2 = new Address(
            "15 Taufa'ahau Road",
            "Nuku'alofa",
            "Tongatapu",
            "Tonga"
        );

        Customer customer2 = new Customer(
            "Mary Tu'ipulotu",
            address2
        );

        Product product4 = new Product(
            "Headphones",
            "H2001",
            79.99,
            1
        );

        Product product5 = new Product(
            "Phone Case",
            "P2002",
            19.99,
            3
        );

        Order order2 = new Order(customer2);

        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // DISPLAY ORDER 1

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():F2}");

        Console.WriteLine();


        // DISPLAY ORDER 2

        Console.WriteLine("========================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("========================================");
        Console.WriteLine();

        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():F2}");
    }
}
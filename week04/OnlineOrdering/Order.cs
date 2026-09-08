using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        StringBuilder label = new StringBuilder();

        label.AppendLine("PACKING LABEL");

        foreach (Product product in _products)
        {
            label.AppendLine(
                $"Product: {product.GetName()} | ID: {product.GetProductId()}"
            );
        }

        return label.ToString();
    }

    public string GetShippingLabel()
    {
        StringBuilder label = new StringBuilder();

        label.AppendLine("SHIPPING LABEL");
        label.AppendLine($"Customer: {_customer.GetName()}");
        label.AppendLine(_customer.GetAddress().GetFullAddress());

        return label.ToString();
    }
}
using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (Product p in _products)
        {
            total += p.TotalCost();
        }

        double shippingCost;
        if (_customer.LivesInUSA())
        {
            shippingCost = 5;
        }
        else
        {
            shippingCost = 35;
        }

        total += shippingCost;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (Product p in _products)
        {
            label += p.Name + " (ID: " + p.ProductId + ")\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += _customer.Name + "\n";
        label += _customer.Address.FullAddress() + "\n";
        return label;
    }
}
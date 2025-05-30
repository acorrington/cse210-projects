public class Order
{
    private Customer _customer;
    private List<Product> _products;

    public Order(Customer customer, List<Product> products)
    {
        _customer = customer;
        _products = products;
    }

    public double GetTotal()
    {
        double total = 0.0;
        foreach (var product in _products)
        {
            total += product.GetTotal();
        }

        total+= _customer.IsInUSA() ? 5.0 : 35.0;

        return total;
    }

    public string GetPackingLabel()
    {
        string packingLabel = $"Packing Label for Order\n";
        packingLabel += "Products:\n";
        foreach (var product in _products)
        {
            packingLabel += $"{product.Display()}\n";
        }
        return packingLabel;
    }

    public string GetShippingLabel()
    {
        string shippingLabel = $"Shipping Label for Order\n";
        shippingLabel += $"Customer: {_customer.GetName()}\n";
        shippingLabel += $"Address: {_customer.GetAddress().Display()}\n";
        return shippingLabel;
    }
}
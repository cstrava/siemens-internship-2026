// See https://aka.ms/new-console-template for more information

using SieMarketTask.Models;
using SieMarketTask.Services;

var orders = new List<Order>
{
    new Order("Ana", new []
    {
        new OrderItem("Laptop", 1, 1200m),
        new OrderItem("Mouse", 2, 25m)
    }),

    new Order("Mihai", new []
    {
        new OrderItem("Monitor", 2, 220m),
        new OrderItem("HDMI Cable", 3, 10m)
    }),

    new Order("Ana", new []
    {
        new OrderItem("Keyboard", 1, 80m),
        new OrderItem("USB-C Hub", 1, 60m)
    }),

    new Order("Ioana", new []
    {
        new OrderItem("Phone", 1, 499m),
    }),

    new Order("Ioana", new []
    {
        new OrderItem("Tablet", 1, 520m),
    }),
};

Console.WriteLine("Order totals:");
foreach (var o in orders)
{
    Console.WriteLine($"- {o.CustomerName}: subtotal={o.Subtotal}€, final={o.CalculateFinalPrice()}€, discount={o.IsDiscountApplicable}");
}

Console.WriteLine();
Console.WriteLine($"Top spender: {OrderAnalytics.GetTopSpenderCustomerName(orders)}");

Console.WriteLine();
Console.WriteLine("Popular products:");
foreach (var p in OrderAnalytics.GetPopularProducts(orders))
{
    Console.WriteLine($"- {p.ProductName}: {p.TotalQuantity} pcs");
}

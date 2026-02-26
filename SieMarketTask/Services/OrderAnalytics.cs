using SieMarketTask.Models;

namespace SieMarketTask.Services;

public static class OrderAnalytics
{
    public static string GetTopSpenderCustomerName(IEnumerable<Order> orders)
    {
        if (orders is null) throw new ArgumentNullException(nameof(orders));

        var totals = orders
            .GroupBy(o => o.CustomerName, StringComparer.OrdinalIgnoreCase)
            .Select(g => new
            {
                Name = g.First().CustomerName,
                Total = g.Sum(o => o.CalculateFinalPrice())
            })
            .ToList();

        if (totals.Count == 0)
            throw new InvalidOperationException("No orders provided.");

        return totals
            .OrderByDescending(x => x.Total)
            .ThenBy(x => x.Name, StringComparer.OrdinalIgnoreCase)
            .First()
            .Name;
    }

    public static IReadOnlyList<(string ProductName, int TotalQuantity)> GetPopularProducts(IEnumerable<Order> orders)
    {
        if (orders is null) throw new ArgumentNullException(nameof(orders));

        return orders
            .SelectMany(o => o.Items)
            .GroupBy(i => i.ProductName, StringComparer.OrdinalIgnoreCase)
            .Select(g => (ProductName: g.First().ProductName, TotalQuantity: g.Sum(i => i.Quantity)))
            .OrderByDescending(x => x.TotalQuantity)
            .ThenBy(x => x.ProductName, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}
namespace SieMarketTask.Models;

public sealed class Order
{
    public string CustomerName { get; }
    public DateTimeOffset CreatedAt { get; }
    public IReadOnlyList<OrderItem> Items { get; }

    public const decimal DiscountThreshold = 500m;
    public const decimal DiscountRate = 0.10m;

    public Order(string customerName, IEnumerable<OrderItem> items, DateTimeOffset? createdAt = null)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            throw new ArgumentException("Customer name cannot be empty.", nameof(customerName));

        var list = items?.ToList() ?? throw new ArgumentNullException(nameof(items));
        if (list.Count == 0)
            throw new ArgumentException("Order must contain at least one item.", nameof(items));

        CustomerName = customerName.Trim();
        Items = list;
        CreatedAt = createdAt ?? DateTimeOffset.UtcNow;
    }

    public decimal Subtotal => Items.Sum(i => i.LineTotal);

    public bool IsDiscountApplicable => Subtotal > DiscountThreshold;

    public decimal CalculateFinalPrice()
    {
        var subtotal = Subtotal;
        var final = subtotal > DiscountThreshold
            ? subtotal * (1m - DiscountRate)
            : subtotal;

        return decimal.Round(final, 2, MidpointRounding.AwayFromZero);
    }
}
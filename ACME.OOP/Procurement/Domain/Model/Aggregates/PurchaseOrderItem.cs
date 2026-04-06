using oop_sample.Procurement.Domain.Model.ValueObjects;
using oop_sample.Shared.Domain.Model.ValueObjects;

namespace oop_sample.Procurement.Domain.Model.Aggregates;

/// <summary>
/// Represents a purchase order item aggregate int the Procurement bounded context.
/// Encapsulates the details of a single item in a purchase order, including the product id, quantity, and unit price. 
/// </summary>
public class PurchaseOrderItem
{
    public ProductId ProductId { get; }
    public int Quantity { get; }
    public Money UnitPrice { get; }

    /// <summary>
    /// Creates a new instance of <see cref="PurchaseOrderItem"/> 
    /// </summary>
    /// <param name="productId">The <see cref="ProductId"/> identifier.</param>
    /// <param name="quantity">The product quantity to purchase.</param>
    /// <param name="unitPrice">The unit price for the product.</param>
    /// <exception cref="ArgumentNullException">Thrown when a required attribute is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when a numeric attribute is out of the expected range.</exception>
    internal PurchaseOrderItem(ProductId productId, int quantity, Money unitPrice)
    {
        ProductId = productId ?? throw new ArgumentNullException(nameof(productId));
        Quantity = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity));
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }
    
    /// <summary>
    /// Calculates the total price of the item. 
    /// </summary>
    /// <returns>The total price for the item, calculated as unit price multiplied by quantity.</returns>
    public Money CalculateItemTotal() => UnitPrice.Multiply(Quantity);
}
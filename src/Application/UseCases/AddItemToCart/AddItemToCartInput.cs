namespace Application.UseCases.AddItemToCart;

public class AddItemToCartInput(Guid customerId, Guid productId, int quantity)
{
    public Guid ProductId { get; } = productId;

    public Guid CustomerId { get; } = customerId;

    public int Quantity { get; } = quantity;
}

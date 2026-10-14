namespace Domain.Entities;

public class ShoppingCart(Guid customerId)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Guid CustomerId { get; } = customerId;


    private readonly List<ShoppingCartItem> _items = [];

    public IReadOnlyCollection<ShoppingCartItem> Items { get { return _items.AsReadOnly(); }  }

    public void AddItem(
        Guid productId, string productName, decimal productPrice, int quantity)
    {
        var existingItem = _items.SingleOrDefault(x => x.ProductId == productId);
        if(existingItem == null )
        {
            _items.Add(new ShoppingCartItem(
                productId,productName,productPrice,quantity));
            return;
        }
        existingItem.Quantity  += quantity;
    }
}

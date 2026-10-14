using Domain.Entities;

namespace Application.Interfaces.Data;

public interface IShoppingCartRepository
{
    Task<ShoppingCart?> GetByCustomerIdAsync(Guid customerId);
    Task SaveAsync(ShoppingCart shoppingCart);
}

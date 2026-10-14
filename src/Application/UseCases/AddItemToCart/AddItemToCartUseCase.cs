using Application.Interfaces.Data;
using Application.Interfaces.UseCases;
using Domain.Entities;

namespace Application.UseCases.AddItemToCart;

public class AddItemToCartUseCase(
    IShoppingCartRepository shoppingCartRepository,
    IProductRepository productRepository
    ) : IAddItemToCartUseCase
{
    public async Task AddItemToCartAsync(AddItemToCartInput input)
    {
        var product = await productRepository.GetByIdAsync(input.ProductId);
        if( product == null )
        {
            return;
        }
        var shoppingCart = 
            await shoppingCartRepository.GetByCustomerIdAsync(input.CustomerId)
            ?? new ShoppingCart(input.CustomerId);

        shoppingCart.AddItem(product.Id,product.Name, product.Price,input.Quantity);
        await shoppingCartRepository.SaveAsync(shoppingCart);
    }
}

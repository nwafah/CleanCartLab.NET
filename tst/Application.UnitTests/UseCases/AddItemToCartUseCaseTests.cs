using Application.Interfaces.Data;
using Application.UseCases.AddItemToCart;
using Domain.Entities;
using NSubstitute;

namespace Application.UnitTests.UseCases
{

    public class AddItemToCartUseCaseTests
    {
        [Fact]
        public async Task AddItemToCartAsync_ValidInput_AddsItemToCart()
        {
        //Arrange
            var shoppingCartRepository = Substitute.For<IShoppingCartRepository>();
            var productRepository = Substitute.For<IProductRepository>();

            var customerId = Guid.NewGuid();
            var shoppingCart = new ShoppingCart(customerId: customerId);
            var product = new Product("Notebook", 10.00m);

            productRepository.GetByIdAsync(product.Id).Returns(product);
            shoppingCartRepository.GetByCustomerIdAsync(customerId)
                .Returns(shoppingCart);

            var useCase = new AddItemToCartUseCase(
                shoppingCartRepository: shoppingCartRepository,
                productRepository: productRepository
                );

            var input = new AddItemToCartInput(customerId: customerId,
                productId: product.Id,
                quantity: 2);
        //Act
            await useCase.AddItemToCartAsync(input);
            //Assert
            var item = Assert.Single(shoppingCart.Items);
            Assert.Equal(product.Id, item.ProductId);
            Assert.Equal(2 , item.Quantity);

            await shoppingCartRepository.Received(1).SaveAsync(shoppingCart);
        }
    }
}

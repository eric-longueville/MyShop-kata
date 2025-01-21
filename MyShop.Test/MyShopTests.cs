using MyShop_kata.Services.Interfaces;
using MyShop_kata.Repositories.DbObjects;
using MyShop_kata.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using MyShop_kata.Entity;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace MyShop.Test;

public class Tests
{
    [Test]
    public async Task TestProduct()
    {
        var mockSet = new Mock<DbSet<Product>>();

        var options = new DbContextOptionsBuilder<MyShopDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        var mockContext = new Mock<MyShopDbContext>(options);
        mockContext.Setup(m => m.Products).Returns(mockSet.Object);

        var service = new MyShopRepository(mockContext.Object);

        Product product = new()
        {
            ProductId = 1,
            ProductName = "TestName",
            ProductBrand = "TestBrand",
            ProductSize = "TestSize"
        };

        var addedProduct = await service.AddProduct(product);

        Assert.That(addedProduct, Is.Not.Null);

        mockSet.Verify(m => m.AddAsync(It.IsAny<Product>(), It.IsAny<CancellationToken>()), Times.Once());
        mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }
}
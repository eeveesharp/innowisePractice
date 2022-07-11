using Shop.DAL.Entities;

namespace Bll.Test.Etities
{
    public class ValidProductEntity
    {
        public static IEnumerable<ProductEntity> ProductEntityList = new List<ProductEntity>
            { new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 } };

        public static ProductEntity ProductEntity = new() { Id = 1, Name = "Test", Price = 100, Quantity = 3 };
    }
}

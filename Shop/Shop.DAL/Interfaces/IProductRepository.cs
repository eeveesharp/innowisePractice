namespace Shop.DAL.Interfaces
{
    public interface IProductRepository<ProductEntity>
    {
        IEnumerable<ProductEntity> GetAll();

        ProductEntity Get(int id);

        ProductEntity Create(ProductEntity item);

        ProductEntity Update(ProductEntity item);

        void Delete(int id);
    }
}

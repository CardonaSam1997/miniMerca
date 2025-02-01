using miniMercado.Entity;
using miniMercado.Model;

namespace miniMercado.Service
{
    public interface IProductService
    {
        Task<List<object>> GetAllProductosAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task<ResponseModel<Producto>> AddProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}

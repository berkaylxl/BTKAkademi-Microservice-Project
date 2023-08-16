using BtkAkademi.Services.ProductAPI.Models.DTO;

namespace BtkAkademi.Services.ProductAPI.Repository
{
	public interface IProductRepository
	{
		Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
		Task<bool> DeleteProduct(int productId);
		Task<ProductDto> GetProductById(int productId);
		Task<IEnumerable<ProductDto>> GetProducts();
	}
}
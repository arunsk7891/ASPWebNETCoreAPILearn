using ASPWebNETCoreAPI.Models;
using System.Collections.Generic;

namespace ASPWebNETCoreAPI.Repository
{
  public interface IProductRepository
  {
    IEnumerable<Product> GetProducts();
    Product GetProductByID(int product);
    void InsertProduct(Product product);
    void DeleteProduct(int productId);
    void UpdateProduct(Product product);
    void Save();
  }
}

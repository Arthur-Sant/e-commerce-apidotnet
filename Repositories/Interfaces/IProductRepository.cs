using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using apidotnetwiwthdapper.Entities;

namespace apidotnetwiwthdapper.Repositories.Interfaces {
    public interface IProductRepository {
        
        Task<Product> SaveAsync(Product product);
        Task<Product> UpdateAsync(int id, Product product);
        Task<List<Product>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
        Task<Product> GetById(int id);

    }
}

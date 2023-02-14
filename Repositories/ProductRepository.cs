using System;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;
using apidotnetwiwthdapper.Entities;
using apidotnetwiwthdapper.DataAcess.Interfaces;
using apidotnetwiwthdapper.Repositories.Interfaces;

namespace apidotnetwiwthdapper.Repositories {
    public class ProductRepository : IProductRepository {

        private readonly IDataBaseContext dataBaseContext;

        public ProductRepository(IDataBaseContext dataBaseContext) {
            this.dataBaseContext = dataBaseContext;
        }

        public async Task<bool> DeleteAsync(int id) {
            var productExist = await dataBaseContext.Connection.GetAsync<Product>(id);

            if(productExist == null) {
                return false;
            }

            string sql = $"update products set isdeleted = 1 where id = {id}";
            await dataBaseContext.Connection.QueryAsync(sql);

            return true;
        }

        public async Task<List<Product>> GetAllAsync() {
            const string sql = "select * from products where isdeleted = 0";

            var productsList = await dataBaseContext.Connection.QueryAsync<Product>(sql);

            return productsList.AsList();
        }

        public async Task<Product> GetById(int id) {
            var product = await dataBaseContext.Connection.GetAsync<Product>(id);

            if(product == null && product.IsDeleted == true) {
                return null;
            }

            return product;
        }

        public async Task<Product> SaveAsync(Product product) {
            product.Id = await dataBaseContext.Connection.InsertAsync(product);

            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product product) {

            var productExist = await dataBaseContext.Connection.GetAsync<Product>(id);

            if(productExist == null) {
                return null;
            }

            await dataBaseContext.Connection.UpdateAsync(product);

            return product;
        }
    }
}

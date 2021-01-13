
namespace WcfService
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    //
    using WcfService.Models;
    using WcfService.ModelsDto;
    using WcfService.ServiceBase;
    //

    public class ServiceProduct : ServiceBase_, IServiceProduct
    {
        public async Task<List<Product>> ShowAsync()
        {
            List<Product> Products = new List<Product>();

            var sqlComd = GetStoreProc("ShowProducts");

            OpenConnection();

            sqlDReader = await sqlComd.ExecuteReaderAsync();

            while (sqlDReader.Read())
                Products.Add(
                    new Product
                    {
                        Id = Convert.ToInt32(sqlDReader[0]),
                        Name = sqlDReader[1].ToString(),
                        Description = sqlDReader[2].ToString(),
                        Price = Convert.ToDecimal(sqlDReader[4]),
                        Quantity = Convert.ToInt32(sqlDReader[3])
                    });

            CloseConnection();

            return Products;
        }

        public async Task<Product> ShowIdAsync(int Id)
        {
            List<Product> Products = new List<Product>();

            var sqlComd = GetStoreProc("ShowProductsId", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = Id
                }

            });

            OpenConnection();

            sqlDReader = await sqlComd.ExecuteReaderAsync();

            Product Product = new Product();
            while (sqlDReader.Read())
                Product =new Product
                {
                    Id = Convert.ToInt32(sqlDReader[0]),
                    Name = sqlDReader[1].ToString(),
                    Description = sqlDReader[2].ToString(),
                    Price = Convert.ToDecimal(sqlDReader[4]),
                    Quantity = Convert.ToInt32(sqlDReader[3])
                };

            CloseConnection();

            return Product;
        }

        public async Task<int> CreateAsync(ProductCreateDto model)
        {
            var sqlComd = GetStoreProc("CreateProducts", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Name",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = model.Name
                },
                new SqlParameter
                {
                    ParameterName = "@Description",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = model.Description
                },
                new SqlParameter
                {
                    ParameterName = "@Price",
                    SqlDbType = SqlDbType.Decimal,
                    Value = model.Price
                },
                new SqlParameter
                {
                    ParameterName = "@Quantity",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Quantity
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

        public async Task<int> UpdateAsync(Product model)
        {
            var sqlComd = GetStoreProc("UpdateProducts", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Id
                },
                new SqlParameter
                {
                    ParameterName = "@Name",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = model.Name
                },
                new SqlParameter
                {
                    ParameterName = "@Description",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 300,
                    Value = model.Description
                },
                new SqlParameter
                {
                    ParameterName = "@Price",
                    SqlDbType = SqlDbType.Decimal,
                    Value = model.Price
                },
                new SqlParameter
                {
                    ParameterName = "@Quantity",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Quantity
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var sqlComd = GetStoreProc("DeleteProducts", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = Id
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }
    }
}


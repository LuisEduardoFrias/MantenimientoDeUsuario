
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

    public class ServiceInvoiceDetail : ServiceBase_, IServiceInvoiceDetail
    {
        public async Task<List<InvoiceDetail>> ShowAsync()
        {
            List<InvoiceDetail> InvoiceDetails = new List<InvoiceDetail>();

            var sqlComd = GetStoreProc("ShowInvoiceDetails");

            OpenConnection();

            sqlDReader = await sqlComd.ExecuteReaderAsync();

            while (sqlDReader.Read())
                InvoiceDetails.Add(
                    new InvoiceDetail
                    {
                        Id = Convert.ToInt32(sqlDReader[0]),
                        Quantity = Convert.ToInt32(sqlDReader[1]),
                        Invoice = new Invoice
                        {
                            Id = Convert.ToInt32(sqlDReader[2]),
                            DateIssued = Convert.ToDateTime(sqlDReader[3])
                        },
                        User = new User
                        {
                            Id = Convert.ToInt32(sqlDReader[4]),
                            FullName = sqlDReader[5].ToString(),
                        },
                        Product = new Product
                        {
                            Id = Convert.ToInt32(sqlDReader[6]),
                            Name = sqlDReader[7].ToString(),
                            Price = Convert.ToDecimal(sqlDReader[8])
                        }
                    });

            CloseConnection();

            return InvoiceDetails;
        }

        public async Task<List<InvoiceDetail>> ShowIdAsync(int Id)
        {
            List<InvoiceDetail> InvoiceDetails = new List<InvoiceDetail>();

            var sqlComd = GetStoreProc("ShowInvoiceDetailId", new SqlParameter[]
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

            while (sqlDReader.Read())
                InvoiceDetails.Add(
                    new InvoiceDetail
                    {
                        Id = Convert.ToInt32(sqlDReader[0]),
                        Quantity = Convert.ToInt32(sqlDReader[1]),
                        Invoice = new Invoice
                        {
                            Id = Convert.ToInt32(sqlDReader[2]),
                            DateIssued = Convert.ToDateTime(sqlDReader[3])
                        },
                        User = new User
                        {
                            Id = Convert.ToInt32(sqlDReader[4]),
                            FullName = sqlDReader[5].ToString(),
                        },
                        Product = new Product
                        {
                            Id = Convert.ToInt32(sqlDReader[6]),
                            Name = sqlDReader[7].ToString(),
                            Price = Convert.ToDecimal(sqlDReader[8])
                        }
                    });


            CloseConnection();

            return InvoiceDetails;
        }

        public async Task<int> CreateAsync(InvoiceDetailCreateDto model)
        {
            var sqlComd = GetStoreProc("CreateInvoiceDetails", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Quantity",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Quantity
                },
                new SqlParameter
                {
                    ParameterName = "@Invoice",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Invoice
                },
                new SqlParameter
                {
                    ParameterName = "@User",
                    SqlDbType = SqlDbType.Int,
                    Value = model.User
                },
                new SqlParameter
                {
                    ParameterName = "@Product",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Product
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

    }
}

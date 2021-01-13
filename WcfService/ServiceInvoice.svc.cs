
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

    public class ServiceInvoice : ServiceBase_, IServiceInvoice
    {
        public async Task<List<Invoice>> ShowAsync()
        {
            List<Invoice> Invoices = new List<Invoice>();

            var sqlComd = GetStoreProc("ShowInvoices");

            OpenConnection();

            sqlDReader = await sqlComd.ExecuteReaderAsync();

            while (sqlDReader.Read())
                Invoices.Add(
                    new Invoice
                    {
                        Id = Convert.ToInt32(sqlDReader[0]),
                        DateIssued = Convert.ToDateTime(sqlDReader[1]),
                        User = new User 
                        { 
                            Id = Convert.ToInt32(sqlDReader[2]), 
                            FullName = sqlDReader[3].ToString() 
                        }
                    });

            CloseConnection();

            return Invoices;
        }

        public async Task<Invoice> ShowIdAsync(int Id)
        {
            List<Invoice> Invoices = new List<Invoice>();

            var sqlComd = GetStoreProc("ShowInvoicesId", new SqlParameter[]
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

            Invoice Invoice = new Invoice();
            while (sqlDReader.Read())
                Invoice = new Invoice
                {
                    Id = Convert.ToInt32(sqlDReader[0]),
                    DateIssued = Convert.ToDateTime(sqlDReader[1]),
                    User = new User
                    {
                        Id = Convert.ToInt32(sqlDReader[2]),
                        FullName = sqlDReader[3].ToString()
                    }
                };

            CloseConnection();

            return Invoice;
        }

        public async Task<int> CreateAsync(InvoiceCreateDto model)
        {
            var sqlComd = GetStoreProc("CreateInvoices", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@DateIssued",
                    SqlDbType = SqlDbType.Date,
                    Value = model.DateIssued
                },
                new SqlParameter
                {
                    ParameterName = "@User_",
                    SqlDbType = SqlDbType.Int,
                    Value = model.User
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

    }
}

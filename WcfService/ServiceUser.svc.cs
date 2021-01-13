
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

    public class ServiceUser : ServiceBase_, IServiceUser
    {
        public async Task<List<User>> ShowAsync()
        {
            List<User> users = new List<User>();

            var sqlComd = GetStoreProc("ShowUsers");

            OpenConnection();

            sqlDReader = await sqlComd.ExecuteReaderAsync();

            while (sqlDReader.Read())
                users.Add(
                    new User
                    {
                        Id = Convert.ToInt32(sqlDReader[0]),
                        FullName = sqlDReader[1].ToString(),
                        BirtDay = Convert.ToDateTime(sqlDReader[2]),
                        CardNumberId = sqlDReader[3].ToString()
                    });

            CloseConnection();

            return users;
        }

        public async Task<User> ShowIdAsync(int Id)
        {
            List<User> users = new List<User>();

            var sqlComd = GetStoreProc("ShowUsersId", new SqlParameter[]
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

            User user = new User();

            while (sqlDReader.Read())
                user = new User
                {
                    Id = Convert.ToInt32(sqlDReader[0]),
                    FullName = sqlDReader[1].ToString(),
                    BirtDay = Convert.ToDateTime(sqlDReader[2]),
                    CardNumberId = sqlDReader[3].ToString()
                };

            CloseConnection();

            return user;
        }

        public async Task<int> CreateAsync(UserCreateDto model)
        {
            var sqlComd = GetStoreProc("CreateUsers", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@FullName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = model.FullName
                },
                new SqlParameter
                {
                    ParameterName = "@BirtDay",
                    SqlDbType = SqlDbType.Date,
                    Value = model.BirtDay
                },
                new SqlParameter
                {
                    ParameterName = "@CardNumberId",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = model.CardNumberId
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

        public async Task<int> UpdateAsync(User model)
        {
            var sqlComd = GetStoreProc("UpdateUsers", new SqlParameter[]
            {
                new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.Int,
                    Value = model.Id
                },
                new SqlParameter
                {
                    ParameterName = "@FullName",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = model.FullName
                },
                new SqlParameter
                {
                    ParameterName = "@BirtDay",
                    SqlDbType = SqlDbType.Date,
                    Value = model.BirtDay
                },
                new SqlParameter
                {
                    ParameterName = "@CardNumberId",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 11,
                    Value = model.CardNumberId
                }

            });

            OpenConnection();

            int value = await sqlComd.ExecuteNonQueryAsync();

            CloseConnection();

            return value;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            var sqlComd = GetStoreProc("DeleteUsers", new SqlParameter[]
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
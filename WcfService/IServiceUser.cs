
namespace WcfService
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.Threading.Tasks;
    //
    using WcfService.Models;
    using WcfService.ModelsDto;
    //

    [ServiceContract]
    public interface IServiceUser
    {
        [OperationContract]
        Task<List<User>> ShowAsync();

        [OperationContract]
        Task<User> ShowIdAsync(int Id);

        [OperationContract]
        Task<int> CreateAsync(UserCreateDto Model);

        [OperationContract]
        Task<int> UpdateAsync(User Model);

        [OperationContract]
        Task<int> DeleteAsync(int Id);
    }

}

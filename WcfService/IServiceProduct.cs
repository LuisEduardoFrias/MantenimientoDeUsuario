
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
    public interface IServiceProduct
    {
        [OperationContract]
        Task<List<Product>> ShowAsync();

        [OperationContract]
        Task<Product> ShowIdAsync(int Id);

        [OperationContract]
        Task<int> CreateAsync(ProductCreateDto Model);

        [OperationContract]
        Task<int> UpdateAsync(Product Model);

        [OperationContract]
        Task<int> DeleteAsync(int Id);
    }

    
}

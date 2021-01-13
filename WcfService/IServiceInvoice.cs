
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
    public interface IServiceInvoice
    {
        [OperationContract]
        Task<List<Invoice>> ShowAsync();

        [OperationContract]
        Task<Invoice> ShowIdAsync(int Id);

        [OperationContract]
        Task<int> CreateAsync(InvoiceCreateDto Model);

    }
}

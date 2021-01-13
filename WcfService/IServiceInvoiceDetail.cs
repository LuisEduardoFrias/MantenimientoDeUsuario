
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
    public interface IServiceInvoiceDetail
    {
        [OperationContract]
        Task<List<InvoiceDetail>> ShowAsync();

        [OperationContract]
        Task<List<InvoiceDetail>> ShowIdAsync(int Id);

        [OperationContract]
        Task<int> CreateAsync(InvoiceDetailCreateDto Model);

    }
}

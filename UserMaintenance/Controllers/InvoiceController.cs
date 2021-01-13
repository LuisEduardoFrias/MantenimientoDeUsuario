
namespace UserMaintenance.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    //
    using UserMaintenance.ServiceInvoice;
    using UserMaintenance.ServiceInvoiceDetail;
    using WcfService.ModelsDto;
    //

    public class InvoiceController : BaseController
    {

        readonly ServiceInvoiceClient _InvoiceClient;
        readonly ServiceInvoiceDetailClient _invoiceDetailClient; 
       public InvoiceController()
        {
            _InvoiceClient = new ServiceInvoiceClient();
            _invoiceDetailClient = new ServiceInvoiceDetailClient();
        }


        public async Task<ActionResult> Index() =>
            View(await _InvoiceClient.ShowAsync());


        public ActionResult CreateInvoice(InvoiceDetailCreateDto invoices) =>
            View(invoices);


        public async Task<ActionResult> DetalleInvoice(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var invoice = await _InvoiceClient.ShowIdAsync(id.Value);

            if (invoice == null)
                return HttpNotFound();

            ViewBag.Id = invoice.Id;
            ViewBag.DateIssued = invoice.DateIssued.ToString("yyy/MM/dd");
            ViewBag.UserName = invoice.User.FullName;

            return View(await _invoiceDetailClient.ShowIdAsync(id.Value));
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateInvoicePost(InvoiceDetailCreateDto invoices) =>
            View(invoices);

    }
}
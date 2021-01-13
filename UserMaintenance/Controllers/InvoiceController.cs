
namespace UserMaintenance.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    //
    using UserMaintenance.ServiceInvoice;
    using UserMaintenance.ServiceInvoiceDetail;
    using UserMaintenance.ServiceProduct;
    using UserMaintenance.ServiceUser;
    using WcfService.Models;
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


        public async Task<ActionResult> CreateInvoice(InvoiceDetailCreateDto invoices)
        {
            @ViewBag.Users = await GetListUser();
            @ViewBag.Products = await GetListProducts();

            return  View(invoices);
        }
            

        private async Task<List<SelectListItem>> GetListUser()
        {
            ServiceUserClient _UserClient = new ServiceUserClient();

            List<SelectListItem> selectListItems = new List<SelectListItem>();

            foreach (var user in await _UserClient.ShowAsync())
                selectListItems.Add(new SelectListItem
                {
                    Text = user.FullName,
                    Value = user.Id.ToString()
                });

            return selectListItems;
        }


        private async Task<List<Product>> GetListProducts()
        {
            ServiceProductClient _ProductClient = new ServiceProductClient();

            return await _ProductClient.ShowAsync();   
        }

        public ActionResult ShowProductPartialView()
        {
            return PartialView();
        }

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
        public ActionResult CreateInvoicePost(InvoiceDetailCreateDto invoices)
        {
            return View(invoices);
        }

    }
}
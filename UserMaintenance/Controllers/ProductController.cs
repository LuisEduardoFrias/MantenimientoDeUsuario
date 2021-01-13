
namespace UserMaintenance.Controllers
{
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    //
    using UserMaintenance.ServiceProduct;
    using WcfService.Models;
    using WcfService.ModelsDto;
    //

    public class ProductController : BaseController
    {
        readonly ServiceProductClient _productClient;
        public ProductController()
        {
            _productClient = new ServiceProductClient();
        }


        public async Task<ActionResult> Index() =>
            View(await _productClient.ShowAsync());

        public ActionResult CreateProduct(ProductCreateDto Product) =>
            View(Product);

        public async Task<ActionResult> EditProduct(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(await _productClient.ShowIdAsync(id.Value));
        }


        public async Task<ActionResult> DeleteProduct(Product product)
        {
            if (product == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(await _productClient.ShowIdAsync(product.Id));
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateProductPost(ProductCreateDto product)
        {
            if (ModelState.IsValid)
            {
                int value = await _productClient.CreateAsync(product);

                if (value == 1)
                    return Redirect("Index");

            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                int value = await _productClient.UpdateAsync(product);

                if (value == 1)
                    return RedirectToAction("Index");
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProduct(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int value = await _productClient.DeleteAsync(id.Value);

            if (value == -1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

    }
}
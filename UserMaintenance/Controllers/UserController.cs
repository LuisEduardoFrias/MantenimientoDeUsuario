
namespace UserMaintenance.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    //
    using UserMaintenance.ServiceUser;
    using WcfService.Models;
    using WcfService.ModelsDto;
    //

    public class UserController : BaseController
    {
        readonly ServiceUserClient _userClient;
        public UserController()
        {
            _userClient = new ServiceUserClient();
        }



        public async Task<ActionResult> Index()
        {
           return View(await _userClient.ShowAsync());
        }


        public ActionResult CreateUser(UserCreateDto user) =>
            View(user);

        public async Task<ActionResult> EditUser(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(await _userClient.ShowIdAsync(id.Value));
        }

        public async Task<ActionResult> DeleteUser(User user)
        {
            if (user == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return View(await _userClient.ShowIdAsync(user.Id));
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUserPost(UserCreateDto user)
        {
            if (ModelState.IsValid)
            {
                int value = await _userClient.CreateAsync(user);

                if (value == 1)
                    return Redirect("Index");

            }

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(User user)
        {
            if (ModelState.IsValid)
            {
                int value = await _userClient.UpdateAsync(user);

                if (value == 1)
                    return RedirectToAction("Index");
            }

            return View(user);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            int value = await _userClient.DeleteAsync(id.Value);

            if (value == -1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

    }
}

namespace UserMaintenance.Controllers
{
    using AutoMapper;
    using System.Web.Mvc;
    using UserMaintenance.Mapper;
    //

    public class BaseController : Controller
    {
        public IMapper mapper;
        public BaseController()
        {
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperConfig());

            }).CreateMapper();
        }
    }
}
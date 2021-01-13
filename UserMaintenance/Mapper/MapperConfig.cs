
namespace UserMaintenance.Mapper
{
    using AutoMapper;
    using WcfService.ModelsDto;
    using WcfService.Models;
    //

    public class MapperConfig :Profile
    {
        public MapperConfig()
        {
            CreateMap<UserCreateDto,User> ();
            CreateMap<ProductCreateDto, Product>();
        }

    }
}
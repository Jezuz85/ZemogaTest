using AutoMapper;

namespace Writter.API.Mappings
{
    /// <summary>
    /// class that performs the different mapping of the application
    /// </summary>
    public class UserProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public UserProfile()
        {
            CreateMap<Writter.API.Dto.User, Writter.Domain.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login))
                .ForMember(des => des.isEditor, opt => opt.MapFrom((src, des) => src.isEditor))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));

            CreateMap<Writter.Domain.Entities.User, Writter.API.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login))
                .ForMember(des => des.isEditor, opt => opt.MapFrom((src, des) => src.isEditor))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));

            CreateMap<Writter.API.Dto.WritterLoginRequest, Writter.API.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login));
        }
    }
}
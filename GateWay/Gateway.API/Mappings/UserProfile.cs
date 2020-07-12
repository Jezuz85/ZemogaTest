using AutoMapper;

namespace Gateway.API.Mappings
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
            CreateMap<Gateway.API.Dto.User, Gateway.Domain.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login))
                .ForMember(des => des.isEditor, opt => opt.MapFrom((src, des) => src.isEditor))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));

            CreateMap<Gateway.Domain.Dto.User, Gateway.API.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login))
                .ForMember(des => des.isEditor, opt => opt.MapFrom((src, des) => src.isEditor))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));

            CreateMap<Gateway.API.Dto.UserLoginRequest, Gateway.API.Dto.User>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login));

            CreateMap<Gateway.API.Dto.UserLoginRequest, Gateway.Domain.Dto.UserLoginRequest>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login));
        }
    }
}
using AutoMapper;

namespace Writter.API.Mappings
{
    public class WritterLoginRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public WritterLoginRequestProfile()
        {
            CreateMap<Writter.API.Dto.WritterLoginRequest, Domain.Dto.WritterLoginRequest>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login));

            CreateMap<Domain.Dto.WritterLoginRequest, Writter.API.Dto.WritterLoginRequest>()
                .ForMember(des => des.user_login, opt => opt.MapFrom((src, des) => src.user_login))
                .ForMember(des => des.password_login, opt => opt.MapFrom((src, des) => src.password_login));
        }
    }

    public class CreatePostRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public CreatePostRequestProfile()
        {
            CreateMap<Writter.API.Dto.CreatePostRequest, Domain.Dto.CreatePostRequest>()
                .ForMember(des => des.idWritter, opt => opt.MapFrom((src, des) => src.idWritter))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body));

            CreateMap<Domain.Dto.CreatePostRequest, Writter.API.Dto.CreatePostRequest>()
                .ForMember(des => des.idWritter, opt => opt.MapFrom((src, des) => src.idWritter))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body));
        }
    }
}
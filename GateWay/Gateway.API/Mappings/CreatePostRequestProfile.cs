using AutoMapper;

namespace Gateway.API.Mappings
{
    public class CreatePostRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public CreatePostRequestProfile()
        {
            CreateMap<Gateway.API.Dto.CreatePostRequest, Gateway.Domain.Dto.CreatePostRequest>()
                .ForMember(des => des.idWritter, opt => opt.MapFrom((src, des) => src.idWritter))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body));

            CreateMap<Gateway.Domain.Dto.CreatePostRequest, Gateway.API.Dto.CreatePostRequest>()
                .ForMember(des => des.idWritter, opt => opt.MapFrom((src, des) => src.idWritter))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body));
        }
    }
}
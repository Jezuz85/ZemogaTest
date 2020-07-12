using AutoMapper;

namespace Gateway.API.Mappings
{
    /// <summary>
    /// class that performs the different mapping of the application
    /// </summary>
    public class PostProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public PostProfile()
        {
            CreateMap<Gateway.API.Dto.Post, Gateway.Domain.Dto.Post>()
                .ForMember(des => des.state, opt => opt.MapFrom((src, des) => src.state))
                .ForMember(des => des.datePublish, opt => opt.MapFrom((src, des) => src.datePublish))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));

            CreateMap<Gateway.Domain.Dto.Post, Gateway.API.Dto.Post>()
                .ForMember(des => des.state, opt => opt.MapFrom((src, des) => src.state))
                .ForMember(des => des.datePublish, opt => opt.MapFrom((src, des) => src.datePublish))
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));
        }
    }

    public class PostRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public PostRequestProfile()
        {
            CreateMap<Gateway.API.Dto.PostRequest, Gateway.Domain.Dto.PostRequest>()
                .ForMember(des => des.state, opt => opt.MapFrom((src, des) => src.state))
                .ForMember(des => des.id_Editor, opt => opt.MapFrom((src, des) => src.id_Editor))
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));
        }
    }

    public class PostDeleteRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public PostDeleteRequestProfile()
        {
            CreateMap<Gateway.API.Dto.PostDeleteRequest, Gateway.Domain.Dto.PostDeleteRequest>()
                .ForMember(des => des.id, opt => opt.MapFrom((src, des) => src.id));
        }
    }
}
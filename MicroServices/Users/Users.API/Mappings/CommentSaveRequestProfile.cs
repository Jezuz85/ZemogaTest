using AutoMapper;

namespace Users.API.Mappings
{
    public class CommentSaveRequestProfile : Profile
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public CommentSaveRequestProfile()
        {
            CreateMap<API.Dto.CommentSaveRequest, Domain.Dto.CommentSaveRequest>()
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body))
                .ForMember(des => des.id_post, opt => opt.MapFrom((src, des) => src.id_post));

            CreateMap<Domain.Dto.CommentSaveRequest, API.Dto.CommentSaveRequest>()
                .ForMember(des => des.body, opt => opt.MapFrom((src, des) => src.body))
                .ForMember(des => des.id_post, opt => opt.MapFrom((src, des) => src.id_post));
        }
    }
}
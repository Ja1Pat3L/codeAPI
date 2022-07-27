using AutoMapper;
using codeAPI.DTOs;
using codeLibrary.Models;

namespace codeAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //
            CreateMap<Tutorial, TutoriaCommentsDto>();
            CreateMap<TutorialForCreateDto, Tutorial>();
            CreateMap<TutorialForUpdateDto, TutoriaCommentsDto>();
            CreateMap<TutorialForUpdateDto, Tutorial>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientForCreateDto, Client>();
            CreateMap<TutorialCommmentForUpdateDto, Client>();
            CreateMap<TutorialComment,TutorialCommentDto>();
            CreateMap<TutorialCommentForCreateDto, TutorialCommentDto>();
            CreateMap<TutorialCommentForUpdateDto, TutorialCommentDto>();
            CreateMap<ClientTutorial, ClientTutorialDto>();

        }
    }
}
                                               
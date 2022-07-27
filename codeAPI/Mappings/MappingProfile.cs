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
            CreateMap<Tutorial, TutorialDto>();
            CreateMap<TutorialForCreateDto, Tutorial>();
            CreateMap<TutorialForUpdateDto, TutorialDto>();
            CreateMap<TutorialForUpdateDto, Tutorial>();
            CreateMap<Client, ClientDto>();
            CreateMap<ClientForCreateDto, Client>();
            CreateMap<ClientForUpdateDto, Client>();
            CreateMap<TutorialComment,TutorialCommentDto>();
            CreateMap<TutorialCommentForCreateDto, TutorialCommentDto>();
            CreateMap<TutorialCommentForUpdateDto, TutorialCommentDto>();
            CreateMap<TutorialCommentForUpdateDto, TutorialComment>();
            CreateMap<ClientTutorial, ClientTutorialDto>();
            CreateMap<TutorialCommentForCreateDto, TutorialComment>(); 

        }
    }
}
                                               
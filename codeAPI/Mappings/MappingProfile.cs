using AutoMapper;
using codeAPI.DTOs;
using codeLibrary.Models;

namespace codeAPI.Mappings
{
    public class MappingProfile : Profile
    {

        #region Mappings for DTO's and Classes
        public MappingProfile()
        {
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
            CreateMap<ClientTutorialDto,ClientTutorial>();
            CreateMap<TutorialCommentForCreateDto, TutorialComment>();
            CreateMap<ClientTutorialForCreateDto, ClientTutorial>();
            CreateMap< ClientTutorial,ClientTutorialDto> ();
            CreateMap < Client,ClientForCreateDto> ();        
        
        }
        #endregion


    }
}
                                               
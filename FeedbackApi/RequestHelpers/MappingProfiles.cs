using AutoMapper;
using FeedbackApi.DTOs.Comment;
using FeedbackApi.DTOs.Suggestion;
using FeedbackApi.DTOs.User;
using FeedbackApi.Entities;

namespace FeedbackApi.RequestHelpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDetailDto, User>().ReverseMap();

            CreateMap<SuggestionDto, Suggestion>().ReverseMap();
            CreateMap<CreateSuggestionDto, Suggestion>().ReverseMap();
            CreateMap<EditSuggestionDto, Suggestion>().ReverseMap();

            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<PostCommentDto, Comment>();
        }
    }
}

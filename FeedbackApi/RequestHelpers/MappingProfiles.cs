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
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserDetailDto, User>().ReverseMap();
            CreateMap<CreateSuggestionDto, Suggestion>().ReverseMap();
            CreateMap<GetCommentDto, Comment>().ReverseMap();
            CreateMap<PostCommentDto, Comment>();
            CreateMap<PostReplyDto, CommentReply>();
        }
    }
}

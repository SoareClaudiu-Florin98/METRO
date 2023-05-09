using AutoMapper;
using METROAssignment.Contracts.Article.Responses;
using METROAssignment.Contracts.Customer.Responses;
using METROAssignment.Contracts.Payment.Responses;

namespace METROAssignment.Application.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Domain.Models.Customer, CustomerResponseDto>();
            CreateMap<Domain.Models.Article, ArticleResponseDto>();
            CreateMap<Domain.Models.Payment, PaymentResponseDto>();
        }
    }
}

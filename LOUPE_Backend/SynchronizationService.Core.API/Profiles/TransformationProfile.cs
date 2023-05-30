using AutoMapper;
using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.DataLayer.Models;

namespace SynchronizationService.Core.API.Profiles
{
    public class TransformationProfile : Profile
    {
        public TransformationProfile()
        {
            CreateMap<TransformationViewModel, Transformation>().ReverseMap();
        }
    }
}

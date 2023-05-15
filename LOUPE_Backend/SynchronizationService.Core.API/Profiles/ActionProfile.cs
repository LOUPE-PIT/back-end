using AutoMapper;
using SynchronizationService.Core.API.ViewModels.Actions;
using SynchronizationService.DataLayer;

namespace SynchronizationService.Core.API.Profiles
{
    public class ActionProfile : Profile
    {
        public ActionProfile()
        {
            CreateMap<PerformedActionViewModel, PerformedAction>().ReverseMap();
        }
    }
}

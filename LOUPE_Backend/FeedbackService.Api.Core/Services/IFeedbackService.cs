using System.Collections.ObjectModel;
using FeedbackService.API.Core.Viewmodels;
using FeedbackService.DAL.Models;

namespace FeedbackService.Api.Core.Services
{
    public interface IFeedbackService
    {
        Task<Collection<Feedback>> GetAll();
        Task<Collection<Feedback>> GetById(Guid id);
        Task<Collection<Feedback>> GetByUserId(Guid id);
        Task<Collection<Feedback>> GetByLogId(Guid id);
        Task DeleteById(FeedbackViewmodel feedbackViewmodel);
        Task Create(FeedbackViewmodel feedbackViewmodel);


    }
}



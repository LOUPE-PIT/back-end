using FeedbackService.DAL.Models;
using System.Collections.ObjectModel;

namespace FeedbackService.DAL.Repository
{
    public interface IFeedbackRepository
    {
        Task<Collection<Feedback>> GetAll();
        Task<Collection<Feedback>> GetById(Guid id);
        Task<Collection<Feedback>> GetByUserId(Guid userId);
        Task<Collection<Feedback>> GetByLogId(Guid logId);
        Task Create(Feedback feedback);
        Task DeleteById(Feedback feedback);
        


    }
}

using FeedbackService.DAL.Models;
using System.Collections.ObjectModel;

namespace FeedbackService.DAL.Repository
{
    public interface IFeedbackRepository
    {
        Task<Collection<FeedbackDbo>> GetAll();
    }
}

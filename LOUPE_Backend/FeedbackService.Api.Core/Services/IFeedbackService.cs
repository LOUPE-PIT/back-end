using System.Collections.ObjectModel;
using FeedbackService.DAL.Models;

namespace FeedbackService.Api.Core.Services
{
    public interface IFeedbackService
    {
        Task<Collection<FeedbackDbo>> GetAll();
    }
}

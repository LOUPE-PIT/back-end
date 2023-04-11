
using FeedbackService.DAL.Models;
using FeedbackService.DAL.Repository;
using System.Collections.ObjectModel;

namespace FeedbackService.Api.Core.Services
{
    public class FeedbackServiceCore : IFeedbackService
    {

        private readonly IFeedbackRepository _feedbackRespository;

        public FeedbackServiceCore(IFeedbackRepository feedbackRespository)
        {
            _feedbackRespository = feedbackRespository;
        }

      
        public async Task<Collection<FeedbackDbo>> GetAll()
        {
            return await _feedbackRespository.GetAll();
        }
    }
}

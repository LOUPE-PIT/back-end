using FeedbackService.DAL.Context;
using FeedbackService.DAL.Models;
using System.Collections.ObjectModel;

namespace FeedbackService.DAL.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDbContext _feedbackDbContext;

        public FeedbackRepository(FeedbackDbContext feedbackDbContext)
        {
            _feedbackDbContext = feedbackDbContext;
        }

        public Task<Collection<FeedbackDbo>> GetAll()
        {
            return Task.FromResult(new Collection<FeedbackDbo>(_feedbackDbContext.FeedbackDbo.ToList()));
        }
    }
}

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

        public Task<Collection<Feedback>> GetAll()
        {
            return Task.FromResult(new Collection<Feedback>(_feedbackDbContext.Feedback.ToList()));
        }

        public Task<Collection<Feedback>> GetById(Guid id)
        {
            return Task.FromResult(new Collection<Feedback>(_feedbackDbContext.Feedback.Where(x => x.FeedbackId == id).ToList()));
        }

        public async Task Create(Feedback feedback)
        {
            await _feedbackDbContext.Feedback.AddAsync(feedback);
            await _feedbackDbContext.SaveChangesAsync();
        }

        public Task<Collection<Feedback>> GetByUserId(Guid userId)
        {
            return Task.FromResult(new Collection<Feedback>(_feedbackDbContext.Feedback.Where(x => x.UserId == userId).ToList()));
        }


        public async Task DeleteById(Feedback feedback)
        {
            _feedbackDbContext.Feedback.Remove(feedback);
            await _feedbackDbContext.SaveChangesAsync();
        }

        public Task<Collection<Feedback>> GetByLogId(Guid logId)
        {
            return Task.FromResult(new Collection<Feedback>(_feedbackDbContext.Feedback.Where(x => x.LogId == logId).ToList()));
        }
    }
}

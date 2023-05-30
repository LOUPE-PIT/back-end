
using AutoMapper;
using FeedbackService.API.Core.Viewmodels;
using FeedbackService.DAL.Models;
using FeedbackService.DAL.Repository;
using System.Collections.ObjectModel;

namespace FeedbackService.Api.Core.Services
{

    public class FeedbackServiceCore : IFeedbackService
    {

        private readonly IFeedbackRepository _feedbackRespository;
        private readonly IMapper _mapper;

        public FeedbackServiceCore(IFeedbackRepository feedbackRespository, IMapper mapper)
        {
            _feedbackRespository = feedbackRespository;
            _mapper = mapper;
        }

        public async Task Create(FeedbackViewmodel feedbackViewmodel)
        {
            Feedback feedback =  _mapper.Map<Feedback>(feedbackViewmodel);

            await _feedbackRespository.Create(feedback);
        }

        public async Task DeleteById(FeedbackViewmodel feedbackViewmodel)
        {
            Feedback feedback = _mapper.Map<Feedback>(feedbackViewmodel);

            await _feedbackRespository.DeleteById(feedback);
        }

        

        public async Task<Collection<Feedback>> GetAll()
        {
            return await _feedbackRespository.GetAll();
        }

        public async Task<Collection<Feedback>> GetById(Guid id)
        {
            return await _feedbackRespository.GetById(id);
        }

        public async Task<Collection<Feedback>> GetByLogId(Guid id)
        {
            return await _feedbackRespository.GetByLogId(id);
        }

        public async Task<Collection<Feedback>> GetByUserId(Guid id)
        {
            return await _feedbackRespository.GetByUserId(id);
        }
    }
}

using APIService.ViewModel;

namespace APIService.Core
{
    public class APICore : IAPICore
    {
        public APICore()
        {

        }

        public Task DeleteById(Guid logId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByLogId(Guid logId)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeedbackViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FeedbackViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<FeedbackViewModel> GetByLogId(Guid logId)
        {
            throw new NotImplementedException();
        }
    }
}

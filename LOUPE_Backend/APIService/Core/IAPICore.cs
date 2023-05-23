using APIService.ViewModel;

namespace APIService.Core
{
    public interface IAPICore
    {
        Task<List<FeedbackViewModel>> GetAll();
        Task<FeedbackViewModel> GetById(Guid id);
        Task<FeedbackViewModel>GetByLogId(Guid logId);
        Task DeleteById(Guid logId);
        Task DeleteByLogId(Guid logId);
    }
}






using Grpc.Net.Client;
using SynchronizationService.Core.API.ViewModels;
using SyncronizationService.API;
using System.Collections.ObjectModel;

namespace SynchronizationService.API.SyncLogService
{
    public class SyncLogService
    {
        private readonly GrpcChannel _channel;
        public SyncLogService()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:7123");
        }
        
        public async Task SendTransformationsToLoggingAsync(Collection<TransformationViewModel> transformations)
        {
            SyncLogRequest request = new SyncLogRequest
            {
                UserId = transformations[0].UserId.ToString(),
                Object = transformations[0].ActionType.ObjectName,
                Action = transformations[0].ActionType.ActionName,
                GroupId = transformations[0].GroupId.ToString(),
                StartSyncronizationId = transformations[0].Id.ToString(),
                EndSyncronizationId = transformations[^1].Id.ToString()
            };

            // SyncLog.SyncLogClient client = new SyncLog.SyncLogClient(_channel);
            // SyncLogReply reply = await client.GenerateLogAsync(request);
        }
    }
}

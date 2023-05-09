using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using SynchronizationService.Core.API.ViewModels;
using SyncronizationService.API;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SynchronizationService.API.SyncLogService
{
    public class SyncLogService
    {
        private readonly GrpcChannel _channel;
        public SyncLogService()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:7123");
        }
        
        public async Task SendTransformationsToLoggingAsync(Collection<TransformationViewModel> transofrmations)
        {
            SyncLogRequest request = new SyncLogRequest
            {
                UserId = transofrmations[0].UserId.ToString(),
                GroupId = transofrmations[0].GroupId.ToString(),
                StartSyncronizationId = transofrmations[0].Id.ToString(),
                EndSyncronizationId = transofrmations[^1].Id.ToString()
            };

            SyncLog.SyncLogClient client = new SyncLog.SyncLogClient(_channel);
            SyncLogReply reply = await client.GenerateLogAsync(request);

            Console.WriteLine(reply.Succeded.ToString());
        }
    }
}

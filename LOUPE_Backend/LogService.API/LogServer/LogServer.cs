using Grpc.Core;
using LogService.API;

namespace LogService.Api.LogServer
{
    public class LogServer : SyncLog.SyncLogBase
    {
        public LogServer()
        {
            
        }

        public override Task<SyncLogReply> GenerateLog(SyncLogRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SyncLogReply
            {
                Succeded = request.EndSyncronizationId != null
            });
        }
    }
}

using Grpc.Core;
using LogService.API;
using LogService.Core.Api.Services;
using LogService.DataAccessLayer.Models;

namespace LogService.Api.LogServer
{
    public class LogServer : SyncLog.SyncLogBase
    {
        //Service
        private readonly ILogService _logService;

        public LogServer(ILogService logService)
        {
            _logService = logService;
        }

        public override Task<SyncLogReply> GenerateLog(SyncLogRequest request, ServerCallContext context)
        {
            var syncText = $"{request.Action} {request.Object}";
            var syncLog = new Log(Guid.Parse(request.UserId), Guid.Parse(request.GroupId), syncText, Guid.Parse(request.StartSyncronizationId), Guid.Parse(request.EndSyncronizationId));
            _logService.SaveSyncLog(syncLog);
            return Task.FromResult(new SyncLogReply
            {
                Succeded = request.EndSyncronizationId != null
            });
        }
    }
}
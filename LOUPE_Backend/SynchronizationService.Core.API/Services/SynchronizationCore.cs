using SynchronizationService.Core.API.ViewModels;
using SynchronizationService.DataLayer;
using SynchronizationService.DataLayer.Models;
using SynchronizationService.DataLayer.Services;

namespace SynchronizationService.Core.API.Services
{
    public class SynchronizationCore
    {
        private readonly TransformationService _context;
        public SynchronizationCore()
        {
            _context = new TransformationService();
        }

        public void Add(TransformationViewModel transformation)
        {
            Transformation newTransformation = new Transformation
            {
                UserId = transformation.UserId,
                ActionType = new PerformedAction
                {
                    ActionName = transformation.ActionType.ActionName,
                    Degrees = transformation.ActionType.Degrees,
                    ObjectName = transformation.ActionType.ObjectName,
                    State = transformation.ActionType.State,
                    XPos = transformation.ActionType.XPos,
                    YPos = transformation.ActionType.YPos,
                    ZPos = transformation.ActionType.ZPos
                },
                RoomCode = transformation.RoomCode,
                TimeStamp = transformation.TimeStamp
            };

            _context.Create(newTransformation);
        }

    }
}

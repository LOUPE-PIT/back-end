namespace SynchronizationService.DataLayer
{
    public class PerformedAction
    {
        public string ObjectName { get; set; } = null!;
        public string ActionName { get; set; } = null!;

        public bool? State { get; set; }
        public double? Degrees { get; set; }
        public double? XPos { get; set; }
        public double? YPos { get; set; }
        public double? ZPos { get; set; }
        public PerformedAction()
        {
            
        }
    }
}
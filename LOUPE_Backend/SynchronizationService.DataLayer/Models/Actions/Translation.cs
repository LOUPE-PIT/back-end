namespace SynchronizationService.DataLayer
{
    public class Translation : ActionType
    {
        double[] XPos { get; set; } = new double[2];
        double[] YPos { get; set; } = new double[2];
        double[] ZPos { get; set; } = new double[2];

    }
}

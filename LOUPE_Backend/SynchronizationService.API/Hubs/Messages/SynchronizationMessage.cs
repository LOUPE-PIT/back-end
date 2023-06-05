using System.Numerics;

namespace SynchronizationService.API.Hubs.Messages
{
    public class SynchronizationMessage
    {
        public MyNumbers NewPosition { get; set; }
        public double DegreesRotation { get; set; }
        public string ObjectName { get; set; }

        public SynchronizationMessage()
        {
            
        }

        public SynchronizationMessage(MyNumbers newPosition, double degreesRotation, string objectName)
        {
            NewPosition = newPosition;
            DegreesRotation = degreesRotation;
            ObjectName = objectName;
        }
    }

    public class MyNumbers
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public MyNumbers(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
    }
}

using System;

namespace TechnicalServiceAutomation
{
    public class Packages
    {
        int PackageId;
        int[] FaultType;
        int[] FixType;
        DateTime FixTime;
        DateTime EntranceTime;
        DateTime ExitTime;
        

        Packages(int packageId, int[] faultType, int[] fixType, DateTime fixTime, DateTime entranceTime, DateTime exitTime)
        {
            PackageId = packageId;
            FaultType = faultType;
            FixType = fixType;
            FixTime = fixTime;
            EntranceTime = entranceTime;
            ExitTime = exitTime;
        }
    }
}

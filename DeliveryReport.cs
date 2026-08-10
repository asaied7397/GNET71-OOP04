namespace GNET71_OOP04
{
    internal static class DeliveryReport
    {
        public static void PrintShipment(
            ITrackable shipment
        )
        {
            Console.WriteLine(
                shipment.GetTrackingStatus()
            );
        }

        public static void PrintInsurance(
            IInsurable shipment
        )
        {
            Console.WriteLine(
                $"Insurance Cost: " +
                $"{shipment.CalculateInsurance():0.00} EGP"
            );
        }
    }
}
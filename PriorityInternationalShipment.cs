namespace GNET71_OOP04
{
    internal class PriorityInternationalShipment
        : InternationalShipment
    {
        public PriorityInternationalShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            string destinationCountry,
            decimal customsFee
        )
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination,
                destinationCountry,
                customsFee
            )
        {
        }

        public sealed override void GenerateCustomsReport()
        {
            Console.WriteLine(
                "Priority International Customs Report"
            );

            Console.WriteLine(
                $"Tracking Code: {TrackingCode}"
            );

            Console.WriteLine(
                $"Destination Country: {DestinationCountry}"
            );

            Console.WriteLine(
                $"Customs Fee: {CustomsFee} EGP"
            );
        }
    }
}
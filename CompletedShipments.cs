namespace GNET71_OOP04
{
    internal sealed class CompletedShipment :
        Shipment,
        ITrackable,
        IInsurable
    {
        public CompletedShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination
        )
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination
            )
        {
        }

        public override decimal EstimatedCost
        {
            get
            {
                return DeliveryFee + (Weight * 5);
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Completed Shipment");

            Console.WriteLine(
                $"Tracking Code : {TrackingCode}"
            );

            Console.WriteLine(
                $"Description   : {Description}"
            );

            Console.WriteLine(
                $"Estimated Cost: {EstimatedCost} EGP"
            );
        }

        public string GetTrackingStatus()
        {
            return
                $"Shipment {TrackingCode} has been Completed.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.05m;
        }
    }
}
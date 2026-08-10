namespace GNET71_OOP04
{
    internal class ExpressShipment :
        Shipment,
        ITrackable,
        IInsurable
    {
        private decimal extraFee;

        public decimal ExtraFee
        {
            get
            {
                return extraFee;
            }

            set
            {
                if (value >= 0)
                {
                    extraFee = value;
                }
            }
        }

        public ExpressShipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination,
            decimal extraFee
        )
            : base(
                trackingCode,
                description,
                weight,
                deliveryFee,
                destination
            )
        {
            ExtraFee = extraFee;
        }

        public override decimal EstimatedCost
        {
            get
            {
                return
                    DeliveryFee +
                    (Weight * 5) +
                    ExtraFee;
            }
        }

        public override void PrintShipment()
        {
            Console.WriteLine("Express Shipment");

            Console.WriteLine(
                $"Tracking Code : {TrackingCode}"
            );

            Console.WriteLine(
                $"Description   : {Description}"
            );

            Console.WriteLine(
                $"Weight        : {Weight} KG"
            );

            Console.WriteLine(
                $"Delivery Fee  : {DeliveryFee} EGP"
            );

            Console.WriteLine(
                $"Extra Fee     : {ExtraFee} EGP"
            );

            Console.WriteLine(
                $"Destination   : {Destination.GetFullAddress()}"
            );

            Console.WriteLine(
                $"Estimated Cost: {EstimatedCost} EGP"
            );
        }

        public string GetTrackingStatus()
        {
            return
                $"Shipment {TrackingCode} is Out for Delivery.";
        }

        public decimal CalculateInsurance()
        {
            return EstimatedCost * 0.08m;
        }
    }
}
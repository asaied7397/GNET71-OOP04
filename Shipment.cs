namespace GNET71_OOP04
{
    internal abstract class Shipment
    {
        private string trackingCode;
        private string description;
        private decimal weight;
        private decimal deliveryFee;

        public string TrackingCode
        {
            get
            {
                return trackingCode;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    description = value;
                }
            }
        }

        public decimal Weight
        {
            get
            {
                return weight;
            }

            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }

        public decimal DeliveryFee
        {
            get
            {
                return deliveryFee;
            }

            private set
            {
                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }

        public DeliveryAddress Destination { get; set; }

        public abstract decimal EstimatedCost { get; }

        public Shipment(string trackingCode)
        {
            this.trackingCode = "Unknown";
            description = "Unknown";
            weight = 1;
            deliveryFee = 50;

            Destination = new DeliveryAddress(
                "Unknown",
                "Unknown",
                0
            );

            if (!string.IsNullOrWhiteSpace(trackingCode))
            {
                this.trackingCode = trackingCode;
            }
        }

        public Shipment(
            string trackingCode,
            string description,
            decimal weight,
            decimal deliveryFee,
            DeliveryAddress destination
        )
        {
            this.trackingCode = "Unknown";
            this.description = "Unknown";
            this.weight = 1;
            this.deliveryFee = 50;
            Destination = destination;

            if (!string.IsNullOrWhiteSpace(trackingCode))
            {
                this.trackingCode = trackingCode;
            }

            if (!string.IsNullOrWhiteSpace(description))
            {
                this.description = description;
            }

            if (weight > 0)
            {
                this.weight = weight;
            }

            if (deliveryFee > 0)
            {
                this.deliveryFee = deliveryFee;
            }
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }

        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }

        public void UpdateWeight(
            decimal newWeight,
            decimal extraPackingWeight
        )
        {
            if (
                newWeight > 0 &&
                extraPackingWeight >= 0
            )
            {
                Weight =
                    newWeight + extraPackingWeight;
            }
        }

        public abstract void PrintShipment();
    }
}
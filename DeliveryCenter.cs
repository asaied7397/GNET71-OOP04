namespace GNET71_OOP04
{
    internal class DeliveryCenter
    {
        private readonly Shipment?[] shipments;

        public string CenterName { get; set; }

        public Driver? Driver { get; set; }

        public DeliveryCenter(string centerName)
        {
            CenterName =
                string.IsNullOrWhiteSpace(centerName)
                    ? "Unknown Center"
                    : centerName;

            shipments = new Shipment?[20];
        }

        public Shipment? this[int index]
        {
            get
            {
                if (
                    index >= 0 &&
                    index < shipments.Length
                )
                {
                    return shipments[index];
                }

                return null;
            }

            set
            {
                if (
                    index >= 0 &&
                    index < shipments.Length
                )
                {
                    shipments[index] = value;
                }
            }
        }

        public Shipment? this[string trackingCode]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(trackingCode))
                {
                    return null;
                }

                for (int i = 0;
                     i < shipments.Length;
                     i++)
                {
                    if (
                        shipments[i] != null &&
                        shipments[i]!.TrackingCode.Equals(
                            trackingCode,
                            StringComparison.OrdinalIgnoreCase
                        )
                    )
                    {
                        return shipments[i];
                    }
                }

                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            if (shipment == null)
            {
                return false;
            }

            for (int i = 0;
                 i < shipments.Length;
                 i++)
            {
                if (shipments[i] == null)
                {
                    shipments[i] = shipment;

                    return true;
                }
            }

            return false;
        }

        public bool RemoveShipment(
            string trackingCode
        )
        {
            if (string.IsNullOrWhiteSpace(trackingCode))
            {
                return false;
            }

            for (int i = 0;
                 i < shipments.Length;
                 i++)
            {
                if (
                    shipments[i] != null &&
                    shipments[i]!.TrackingCode.Equals(
                        trackingCode,
                        StringComparison.OrdinalIgnoreCase
                    )
                )
                {
                    shipments[i] = null;

                    return true;
                }
            }

            return false;
        }

        public void PrintAllShipments()
        {
            Console.WriteLine(
                "=========================================="
            );

            Console.WriteLine(
                $"Delivery Center: {CenterName}"
            );

            if (Driver != null)
            {
                Console.WriteLine(
                    $"Driver: {Driver.FullName}"
                );
            }

            Console.WriteLine(
                "=========================================="
            );

            foreach (Shipment? shipment in shipments)
            {
                if (shipment != null)
                {
                    shipment.PrintShipment();

                    Console.WriteLine(
                        "------------------------------------------"
                    );
                }
            }
        }

        public void PrintTrackingStatuses()
        {
            foreach (Shipment? shipment in shipments)
            {
                if (shipment is ITrackable trackable)
                {
                    Console.WriteLine(
                        trackable.GetTrackingStatus()
                    );
                }
            }
        }
    }
}
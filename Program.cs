namespace GNET71_OOP04;

class Program
{
    static void Main(string[] args)
    {
        #region Question01
        // a) Abstraction means hiding unnecessary implementation details and exposing only the essential
        // behavior that other parts of the program need.
        // b) Abstraction is one of the four pillars of OOP because it reduces complexity, hides implementation
        // details, provides clear contracts, and allows developers to work with objects through their
        // essential behavior rather than their internal implementation.
        #endregion

        #region Question02
        // a) An abstract class can contain fields, constructors, implemented members, and abstract members, 
        // while an interface mainly defines a contract that implementing classes must follow.
        // b) Choose an interface when you want to define a contract that multiple classes can implement, 
        // and choose an abstract class when you want to provide a common base class with shared implementation
        // for related classes. 
        // c) A class cannot inherit from multiple abstract classes because C# does not support multiple 
        // class inheritance. However, a class can implement multiple interfaces.
        #endregion

        #region Practical Question
        DeliveryAddress standardAddress = new DeliveryAddress(
                    "Cairo",
                    "Tahrir Street",
                    15
                );
        DeliveryAddress expressAddress = new DeliveryAddress(
                "Giza",
                "Faisal Street",
                20
            );
        DeliveryAddress internationalAddress = new DeliveryAddress(
                "Cairo",
                "Airport Road",
                30
            );
        StandardShipment standardShipment = new StandardShipment(
                "SH001",
                "Laptop",
                3,
                80,
                standardAddress
            );
        ExpressShipment expressShipment = new ExpressShipment(
                "SH002",
                "Mobile Phone",
                2,
                60,
                expressAddress,
                30
            );
        InternationalShipment internationalShipment = new InternationalShipment(
                "SH003",
                "Television",
                8,
                120,
                internationalAddress,
                "Germany",
                100
            );
        Driver driver = new Driver(
                1,
                "Ahmed Mohamed",
                "01000000000"
            );

        DeliveryCenter deliveryCenter = new DeliveryCenter("Cairo Center");
        deliveryCenter.Driver = driver;
        deliveryCenter.AddShipment(standardShipment);
        deliveryCenter.AddShipment(expressShipment);
        deliveryCenter.AddShipment(internationalShipment);
        #region Print All Shipments
        Console.WriteLine("==========================================");
        Console.WriteLine("Delivery Center");
        Console.WriteLine("==========================================");
        deliveryCenter.PrintAllShipments();
        #endregion
        #region Tracking Status
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Tracking Status");
        Console.WriteLine("==========================================");
        deliveryCenter.PrintTrackingStatuses();
        #endregion
        #region Insurance
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Insurance");
        Console.WriteLine("==========================================");
        Console.WriteLine($"Standard Shipment Insurance : " + $"{standardShipment.CalculateInsurance():0.00} EGP");
        Console.WriteLine($"Express Shipment Insurance : " + $"{expressShipment.CalculateInsurance():0.00} EGP");
        Console.WriteLine($"International Shipment Insurance : " + $"{internationalShipment.CalculateInsurance():0.00} EGP");
        #endregion
        #region DeliveryReport
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("DeliveryReport");
        Console.WriteLine("==========================================");
        DeliveryReport.PrintShipment(standardShipment);
        DeliveryReport.PrintShipment(expressShipment);
        DeliveryReport.PrintShipment(internationalShipment);
        Console.WriteLine();
        DeliveryReport.PrintInsurance(standardShipment);
        DeliveryReport.PrintInsurance(expressShipment);
        DeliveryReport.PrintInsurance(internationalShipment);
        #endregion
        #region ITrackable Polymorphism
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("ITrackable[] Polymorphism");
        Console.WriteLine("==========================================");
        ITrackable[] trackableShipments =        {
                standardShipment,
                expressShipment,
                internationalShipment
            };
        foreach (ITrackable shipment in trackableShipments)
        {
            Console.WriteLine(shipment.GetTrackingStatus());
        }
        #endregion
        #region IInsurable Polymorphism
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("IInsurable[] Polymorphism");
        Console.WriteLine("==========================================");
        IInsurable[] insurableShipments =       {
                standardShipment,
                expressShipment,
                internationalShipment
            };
        foreach (IInsurable shipment in insurableShipments)
        {
            Console.WriteLine($"Insurance: " + $"{shipment.CalculateInsurance():0.00} EGP");
        }
        #endregion
        #region Preserve Assignment 03 Overloading
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("UpdateWeight Overloading");
        Console.WriteLine("==========================================");
        Console.WriteLine($"Original Weight: {standardShipment.Weight} KG");
        standardShipment.UpdateWeight(5);
        Console.WriteLine($"Updated Weight: {standardShipment.Weight} KG");
        standardShipment.UpdateWeight(
            5,
            0.5m
        );
        Console.WriteLine($"Updated Weight After Packing: " + $"{standardShipment.Weight} KG");
        #endregion
        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("Interface Polymorphism " + "Demonstrated Successfully.");
        Console.WriteLine("==========================================");
        #endregion
    }
}

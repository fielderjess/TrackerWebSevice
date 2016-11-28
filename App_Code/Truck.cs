using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Truck
/// </summary>
public class Truck
{

    public Int32 TruckId { get; set; }
    public string TowType { get; set; }
    public string Driver { get; set; }
    public string Status { get; set; }
    public string ETA { get; set; }

    public Truck() { }

    public Truck(Int32 TruckId, string TowType, string Driver)
    {
        this.TruckId = TruckId;
        this.TowType = TowType;
        this.Driver = Driver;
    }

    public Truck(Int32 TruckId, string TowType, string Driver, string Status, string ETA)
    {
        this.TruckId = TruckId;
        this.TowType = TowType;
        this.Driver = Driver;
        this.Status = Status;
        this.ETA = ETA;
    }

    public void dummyData()
    {

        this.TruckId = 222;
        this.TowType = "Test";
        this.Driver = "Test";
        this.Status = "Test";
        this.ETA = "Test";

    }

}
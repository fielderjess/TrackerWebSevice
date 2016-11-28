using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Call
/// </summary>
public class Call
{

    public Int32 CallId { get; set; }
    public string PHONEH { get; set; }
    public Int32 EXT { get; set; }
    public Int32 PRIORITY { get; set; }
    public string REQDBY { get; set; }
    public string Stage { get; set; }
    public string Driver { get; set; }
    public Int32 TRUCK { get; set; }
    public string zone { get; set; }
    public string ORIG { get; set; }
    public string REASON { get; set; }
    public string CALLTIM { get; set; }
    public string STATUS { get; set; }
    public string DEST { get; set; }
    public string REM1 { get; set; }

    public Call() { }

    public Call(string PHONEH, string REQDBY, string ORIG, string CALLTIM, string DEST)
    {
        this.PHONEH = PHONEH;
        this.REQDBY = REQDBY;
        this.ORIG = ORIG;
        this.CALLTIM = CALLTIM;
        this.DEST = DEST;
    }

    public void dummyData()
    {
        this.CallId = 111;
        this.PHONEH = "555-555-5555";
        this.EXT = 333;
        this.PRIORITY = 2;
        this.REQDBY = "Test";
        this.Stage = "A";
        this.Driver = "Test";
        this.TRUCK = 999;
        this.zone = "Test";
        this.ORIG = "Test";
        this.REASON = "Test";
        this.CALLTIM = DateTime.Now.TimeOfDay.ToString();
        this.STATUS = "Test";
        this.DEST = "Test";
        this.REM1 = "Test";
    }



}
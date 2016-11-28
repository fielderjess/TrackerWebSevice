using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Web service for the new Tracker Management web app
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Tracker2ws : System.Web.Services.WebService
{

    public Tracker2ws()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    /*
     * Begin example functions
     */

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public void HelloUniverse()
    {
        serialize("Hello Universe");
    }

    [WebMethod]
    public void getStudents()
    {
        List<Student> ret = new List<Student>();

        try
        {
            using (ds.spGetStudentsDataTable tbl = (new dsTableAdapters.spGetStudentsTableAdapter()).GetData(false)){
                foreach (ds.spGetStudentsRow rs in tbl)
                    ret.Add(new Student(rs.StudentId, rs.name, rs.isActive));
            }
        } catch(Exception ex)
        {
            serialize("Error: 010 - " + ex.Message);
            return;
        }

        serialize(ret);
    }

    [WebMethod]
    public void getStudentById(Int32 studentId)
    {
        List<Student> ret = new List<Student>();
        try
        {
            using (ds.spGetStudentByIdDataTable tbl = (new dsTableAdapters.spGetStudentByIdTableAdapter()).GetData(studentId))
            {
                foreach (ds.spGetStudentByIdRow rs in tbl)
                    ret.Add(new Student(rs.StudentId, rs.name, rs.isActive));
            }
        }
        catch (Exception ex)
        {
            serialize("Error: 010 - " + ex.Message);
            return;
        }

        serialize(ret);
    }

    [WebMethod]
    public void addStudentPhoneNumber(Int32 studentId, string Number)
    {
        (new dsTableAdapters.QueriesTableAdapter()).spAddStudentPhoneNumber(studentId, Number);
    }

    [WebMethod]
    public void getPhoneNumbersByStudent(Int32 studentId)
    {
        List<KeyValuePair<Int32, string>> ret = new List<KeyValuePair<Int32, string>>();
        try
        {
            using (ds.spGetStudentPhoneNumsDataTable tbl = (new dsTableAdapters.spGetStudentPhoneNumsTableAdapter()).GetData(studentId))
            {
                foreach (ds.spGetStudentPhoneNumsRow rs in tbl)
                    ret.Add(new KeyValuePair<Int32, string>(rs.StudentPhoneNumsId, rs.Number));
            }
        }
        catch (Exception ex)
        {
            serialize("Error: 010 - " + ex.Message);
            return;
        }

        serialize(ret);
    }

    [WebMethod]
    public void addStudent(string name)
    {
        (new dsTableAdapters.QueriesTableAdapter()).spAddStudent(name);
    }

    /*
     * Begin Tracker Code
     */

    [WebMethod]
    public void addCall()
    {

    }

    private Call dummyCall()
    {
        Call c = new Call();
        c.dummyData();
        return c;
    }

    [WebMethod]
    public void getUnresolvedCalls()
    {
        /*
        *List<Call> ret = new List<Call>();
        *
        *try
        *{
        *    using (ds.spGetUnresolvedCallsDataTable tbl = (new dsTableAdapters.spGetUnresolvedCallsTableAdapter()).GetData(false))
        *    {
        *        foreach (ds.spUnresolvedCallsRow rs in tbl)
        *            ret.Add(new Call(so many bits));
        *    }
        *}
        *catch (Exception ex)
        *{
        *    serialize("Error: 010 - " + ex.Message);
        *    return;
        *}
        *
        *serialize(ret);
        */

        List<Call> ret = new List<Call>();
        for (int i = 0; i < 5; i++)
            ret.Add(dummyCall());

        serialize(ret);

    }

    private Truck dummyTruck()
    {
        Truck t = new Truck();
        t.dummyData();
        return t;
    }

    [WebMethod]
    public void getActiveTrucks()
    {

        List<Truck> ret = new List<Truck>();
        for (int i = 0; i < 5; i++)
            ret.Add(dummyTruck());

        serialize(ret);

    }

    /*
     * Provided by Dr. Michael Stahr. Converts objects to JSON format.
     */
    private void serialize(Object obj)
    {
        try
        {
            Context.Response.ContentType = "application/json";
            Context.Response.Write(new JavaScriptSerializer().Serialize(obj));
            Context.Response.Flush();
        }
        catch (Exception) { }
    }

}

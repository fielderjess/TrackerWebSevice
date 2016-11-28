using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// 
/// Used as part of an example of a web service.
/// 
public class Student
{

    public string name { get; set; }
    public Int32 studentId { get; set; }
    public bool isActive { get; set; }
    public List<string> phoneNums { get; set; }

    public Student() { }

    public Student(Int32 studentId, string name, bool isActive)
    {
        this.studentId = studentId;
        this.name = name;
        this.isActive = isActive;

        phoneNums = new List<String>();
    }

    public void addPhone(string num)
    {
        phoneNums.Add(num);
    }
}

public class PhoneNumber
{
    public Int32 StudentPhoneNumsId { get; set; }
    public string Number { get; set; }
    public Int32 StudentId { get; set; }

    public PhoneNumber() { }

    public PhoneNumber(string number)
    {
        this.Number = number;
    }

    public PhoneNumber(Int32 StudentPhoneNumsId, Int32 StudentId, string number)
    {
        this.StudentPhoneNumsId = StudentPhoneNumsId;
        this.StudentId = StudentId;
        this.Number = number;
    }
}
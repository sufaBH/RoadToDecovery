using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for destination
/// </summary>
public class destination
{
    string type;//סוג יעד
    string name;//שם
    string area;//אזור
    string direction;//הוראות הגעה
    Volunteer responsible;//רכז אחראי
    string status;//סטטוס יעד
    string remarks;//הערות
    string managerName;//שם מנהל יעד
    string managerLastName;//שם משפחה מנהל יעד
    int managerPhones;//טלפון מנהל יעד
    int managerPhones2;//טלפון מנהל יעד

    public string Type { get => type; set => type = value; }
    public string Name { get => name; set => name = value; }
    public string Area { get => area; set => area = value; }
    public string Direction { get => direction; set => direction = value; }
    public Volunteer Responsible { get => responsible; set => responsible = value; }
    public string Status { get => status; set => status = value; }
    public string Remarks { get => remarks; set => remarks = value; }
    public string ManagerName { get => managerName; set => managerName = value; }
    public string ManagerLastName { get => managerLastName; set => managerLastName = value; }
    public int ManagerPhones { get => managerPhones; set => managerPhones = value; }
    public int ManagerPhones2 { get => managerPhones2; set => managerPhones2 = value; }

    public destination(string _type, string _name, string _area, string _direction, Volunteer _responsible, string _status,
        string _remarks, string _managerName, string _managerLastName, int _managerPhones, int _managerPhones2)
    {
        Type = _type;
        Name = _name;
        Area = _area;
        Direction = _direction;
        Responsible = _responsible;
        Status = _status;
        Remarks = _remarks;
        ManagerName = _managerName;
        ManagerLastName = _managerLastName;
        ManagerPhones = _managerPhones;
        ManagerPhones2 = _managerPhones2;

    }

    public destination()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public destination(string _name)
    {
        Name = _name;
    }

    public DataTable read()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("RoadDBconnectionString", "Destination");
        return dbs.dt;
    }

 //   public List<destination> getListdestination()
   // {
  //      DBservices dbs = new DBservices();
  //      List<destination> listd = new List<destination>();
  //      listd = dbs.getListdestination("RoadDBconnectionString", "Destination");
 //       return listd;
   // }
}
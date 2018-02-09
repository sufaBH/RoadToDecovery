using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Ride
/// </summary>
public class Ride
{
    int rideNum;//מספר הסעה
    List<RidePat> rpatList;//הסעות חולים
    string availableSpaces;//כמות מקומות פנויים בנסיעה
    // שדה מחושב לפי כמות מקומות הסעה מסיע פחות כמות מקומות הסעות חולים
    destination start;//מקום התחלה
    destination finish;//מקום סיום
    string area; //אזור
    string day;//יום הסעה
    DateTime date; //תאריך הסעה
    DateTime leavingHour;//שעת יציאה
    List<string> addition;//כלי עזר - נלקח מפרטי הסעה חולה
    Volunteer coordinator;// רכז אחראי
    string remark;//הערות
    public Ride()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable read()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("RoadDBconnectionString", "Ride");
        return dbs.dt;
    }
}
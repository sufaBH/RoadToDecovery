using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Volunteer
/// </summary>
public class Volunteer
{
    string displayName; //מזהה ייחודי
    string firstNameH;//שם פרטי בעברית
    string firstNameA;//שם פרטי בערבית
    string lastNameH;//שם משפחה בעברית
    string lastNameA;//שם משפחה בערבית
    string cellPhone;//טלפון נייד
    string cellPhone2;//טלפון נייד
    string homePhone;//טלפון
    string city;//יישוב
    string address;//רחוב
    string gender;//מין
    string typeVol;//סוג מתנדב
    string email;//אי מייל
    string birthdate;//תאריך לידה
    string preferRoute1;
    string preferRoute2;
    string preferRoute3;
    string day1;
    string day2;
    string day3;
    string hour1;
    string hour2;
    string hour3;
    string joinDate;//תאריך הצטרפות
    string status;//סטטוס
    string knowArabic;//יודע ערבית?

    public string DisplayName { get => displayName; set => displayName = value; }
    public string FirstNameH { get => firstNameH; set => firstNameH = value; }
    public string FirstNameA { get => firstNameA; set => firstNameA = value; }
    public string LastNameH { get => lastNameH; set => lastNameH = value; }
    public string LastNameA { get => lastNameA; set => lastNameA = value; }
    public string CellPhone { get => cellPhone; set => cellPhone = value; }
    public string CellPhone2 { get => cellPhone2; set => cellPhone2 = value; }
    public string HomePhone { get => homePhone; set => homePhone = value; }
    public string City { get => city; set => city = value; }
    public string Address { get => address; set => address = value; }
    public string Gender { get => gender; set => gender = value; }
    public string TypeVol { get => typeVol; set => typeVol = value; }
    public string Email { get => email; set => email = value; }
    public string Birthdate { get => birthdate; set => birthdate = value; }
    public string PreferRoute1 { get => preferRoute1; set => preferRoute1 = value; }
    public string PreferRoute2 { get => preferRoute2; set => preferRoute2 = value; }
    public string PreferRoute3 { get => preferRoute3; set => preferRoute3 = value; }
    public string Day1 { get => day1; set => day1 = value; }
    public string Day2 { get => day2; set => day2 = value; }
    public string Day3 { get => day3; set => day3 = value; }
    public string Hour1 { get => hour1; set => hour1 = value; }
    public string Hour2 { get => hour2; set => hour2 = value; }
    public string Hour3 { get => hour3; set => hour3 = value; }
    public string JoinDate { get => joinDate; set => joinDate = value; }
    public string Status { get => status; set => status = value; }
    public string KnowArabic { get => knowArabic; set => knowArabic = value; }

    public Volunteer()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Volunteer(string _firstNameH,string __firstNameA, string _lastNameH, string _lastNameA, string _cellPhone, string _cellPhone2, string _homePhone, 
        string _city,string _address, string _email,string _birthdate, string _joindate, string _status, string _gender,string _knowArabic,
        string _preferRoute1, string _preferRoute2, string _preferRoute3, string _day1, string _day2, string _day3,
        string _hour1, string _hour2, string _hour3, string _typeVol)
    {
        FirstNameH = _firstNameH;
        FirstNameA = __firstNameA;
        LastNameH = _lastNameH;
        LastNameA = _lastNameA;
        CellPhone = _cellPhone;
        CellPhone2 = _cellPhone2;
        HomePhone = _homePhone;
        City = _city;
        Address = _address;
        Email = _email;
        Birthdate = _birthdate;
        JoinDate = _joindate;
        Status = _status;
        Gender = _gender;
        PreferRoute1 = _preferRoute1;
        PreferRoute2 = _preferRoute2;
        PreferRoute3 = _preferRoute3;
        Day1 = _day1;
        Hour1 = _hour1;
        Day2 = _day2;
        Hour2 = _hour2;
        Day3 = _day3;
        Hour3 = _hour3;
        TypeVol = _typeVol;
        KnowArabic = _knowArabic;
    }

    public Volunteer(string _displayName, string _firstNameA,string _firstNameH, string _lastNameH , string _lastNameA ,
    string _cellPhone,string _cellPhone2 , string _homePhone, string _city, string _street ,string _typeVol, string _email ,string _preferDay1 ,
    string _preferHour1 ,string _preferDay2, string _preferHour2, string _preferDay3 , string _preferHour3, string _preferRoute1 ,string _preferRoute2 ,
    string _preferRoute3 , string _joinDate, string _statusVolunteer ,string _knowArabic,string _birthdate , string _gender)
    {
        DisplayName = _displayName;
        FirstNameH = _firstNameH;
        FirstNameA = _firstNameA;
        LastNameH = _lastNameH;
        LastNameA = _lastNameA;
        CellPhone = _cellPhone;
        CellPhone2 = _cellPhone2;
        HomePhone = _homePhone;
        City = _city;
        Address = _street;
        Email = _email;
        Birthdate = _birthdate;
        JoinDate = _joinDate;
        Status = _statusVolunteer;
        Gender = _gender;
        PreferRoute1 = _preferRoute1;
        PreferRoute2 = _preferRoute2;
        PreferRoute3 = _preferRoute3;
        Day1 = _preferDay1;
        Hour1 = _preferHour1;
        Day2 = _preferDay2;
        Hour2 = _preferHour2;
        Day3 = _preferDay3;
        Hour3 = _preferHour3;
        TypeVol = _typeVol;
        KnowArabic = _knowArabic;
    }

    public Volunteer(string _firstNameH, string _lastNameH, string _cellPhone)
    {
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        CellPhone = _cellPhone;
    }
    public Volunteer(string _displayName)
    {
        DisplayName= _displayName;
    }
    public Volunteer(string _displayName,string _firstNameH, string _lastNameH, string _cellPhone)
    {
        DisplayName = _displayName;
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        CellPhone = _cellPhone;
    }


    public DataTable read()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("RoadDBconnectionString", "Volunteer");
        return dbs.dt;
    }

    public List<Volunteer> getList()
    {
        DBservices dbs = new DBservices();
        List<Volunteer> listV = new List<Volunteer>();
        listV = dbs.getList("RoadDBconnectionString", "Volunteer");
        return listV;
    }
    
        public List<Volunteer> getrespList(string resp)
    {
        DBservices dbs = new DBservices();
        List<Volunteer> listV = new List<Volunteer>();
        listV = dbs.getrespList("RoadDBconnectionString", "Volunteer", resp);
        return listV;
    }

    public Volunteer geUser(string phoneNumber)
    {
        DBservices dbs = new DBservices();
        Volunteer v= new Volunteer();
        v = dbs.getUser("RoadDBconnectionString", "Volunteer", phoneNumber);
        return v;
    }
}
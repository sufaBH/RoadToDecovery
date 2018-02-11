using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Escorted
/// </summary>
public class Escorted
{
    Patient pat;//חולה
    string displayName; //מזהה ייחודי
    string firstNameH;//שם פרטי עברית
    string firstNameA;//שם פרטי ערבית
    string lastNameH;// שם משפחה עברית
    string lastNameA;//שם משפחה ערבית
    string addrees;//כתובת
    int cellPhone;//טלפון נייד
    int cellPhone2;//טלפון 
    int homePhone;//טלפון בית
    string status;//סטטוס
    string contactType;//קרבה לחולה
    string gender;

    public Escorted(Patient _pat, string _firstNameH, string _firstNameA, string _lastNameH, string _lastNameA,
        string _addrees, int _cellPhone, int _cellPhone2, int _homePhone, string _status, string _contactType, string _gender)
    {
        Pat = _pat;
        FirstNameA = _firstNameA;
        FirstNameH = _firstNameH;
        LastNameA = _lastNameA;
        LastNameH = _lastNameH;
        Addrees = _addrees;
        CellPhone = _cellPhone;
        CellPhone2 = _cellPhone2;
        HomePhone = _homePhone;
        Status = _status;
        ContactType = _contactType;
        Gender = _gender;
    }
         public Escorted(string _displayName, string _firstNameH, string _firstNameA, string _lastNameH, string _lastNameA,
         int _cellPhone, int _cellPhone2, int _homePhone, string _addrees, string _status, string _contactType, string _gender)
    {

        DisplayName = _displayName;
        FirstNameA = _firstNameA;
        FirstNameH = _firstNameH;
        LastNameA = _lastNameA;
        LastNameH = _lastNameH;
        Addrees = _addrees;
        CellPhone = _cellPhone;
        CellPhone2 = _cellPhone2;
        HomePhone = _homePhone;
        Status = _status;
        ContactType = _contactType;
        Gender = _gender;
    }
    public Escorted()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Escorted(string _displayname,string _firstNameH,string _lastNameH,int _cellPhone)
    {
        DisplayName = _displayname;
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        CellPhone = _cellPhone;
    }

    public Escorted(string _displayname)
    {
        DisplayName = _displayname;
    }
    public string FirstNameH { get => firstNameH; set => firstNameH = value; }
    public string FirstNameA { get => firstNameA; set => firstNameA = value; }
    public string LastNameH { get => lastNameH; set => lastNameH = value; }
    public string LastNameA { get => lastNameA; set => lastNameA = value; }
    public string Addrees { get => addrees; set => addrees = value; }
    public int CellPhone { get => cellPhone; set => cellPhone = value; }
    public string Status { get => status; set => status = value; }
    public string ContactType { get => contactType; set => contactType = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public string Gender { get => gender; set => gender = value; }
    public int CellPhone2 { get => cellPhone2; set => cellPhone2 = value; }
    public int HomePhone { get => homePhone; set => homePhone = value; }
    public Patient Pat { get => pat; set => pat = value; }

    public DataTable read()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("RoadDBconnectionString", "Escorted");
        return dbs.dt;
    }

    
        public List<Escorted> getListEscorted(string displayNamePat)
    {
        DBservices dbs = new DBservices();
        List<Escorted> listE = new List<Escorted>();
        listE = dbs.getListEscorted("RoadDBconnectionString", "Escorted", displayNamePat);
        return listE;
    }
}
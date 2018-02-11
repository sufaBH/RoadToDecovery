using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for Patient
/// </summary>
public class Patient
{
    string displayName; //מזהה ייחודי
    int id;//תעודת זהות
    string firstNameH;// שם פרטי בעברית
    string firstNameA;// שם פרטי בערבית
    string lastNameH;// שם משפחה בעברית
    string lastNameA;// שם משפחה בערבית
    string birthDate;// תאריך לידה
    string city;//יישוב
    Destination barrier;//מחסום
    Destination hospital;//בית חולים
    string department;//מחלקה
    string gender;//מין
    int cellPhone;//טלפון נייד
    int cellPhone1;//טלפון נייד1
    int homePhone;//טלפון
    string livingArea;//אזור (מחסום)
    List<Escorted> escortedList;//מלווים
    List<RidePat> ridePatList;//הסעות חולה
    string addition;//כלי עזר
    string history;//היסטוריה רפואית
    string status;//סטטוס
    string remarks;//הערות
    public Patient()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Patient(string _firstNameH, string _lastNameH, int _cellPhone)
    {
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        CellPhone = _cellPhone;
    }

    public Patient(string _displayName,string _firstNameH, string _lastNameH, int _cellPhone)
    {
        DisplayName = _displayName;
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        CellPhone = _cellPhone;
    }
    public Patient(string _displayName)
    {
        DisplayName = _displayName;
    }


    public Patient(string _firstNameH, string _firstNameA, string _lastNameH, string _lastNameA, int _cellPhone, int _cellPhone1,int _homePhone,
      string _city, string _gender, string _birthdate, Destination _barrier, Destination _hospital,
      string _department, string _area, string _status, string _addition,string _history, string _remarks)
    {
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        FirstNameA = _firstNameA;
        LastNameA = _lastNameA;
        CellPhone = _cellPhone;
        CellPhone1 = _cellPhone1;
        HomePhone = _homePhone;
        City = _city;
        Gender = _gender;
        BirthDate = _birthdate;
        Barrier = _barrier;
        Hospital= _hospital;
        Department = _department;
        LivingArea = _area;
        Status = _status;
        Addition = _addition;
        Remarks = _remarks;
        History = _history;
    }

    public Patient(string _displayName,string _firstNameH, string _firstNameA, string _lastNameH, string _lastNameA, int _cellPhone, 
        int _cellPhone1, int _homePhone, string _city, string _gender, string _birthdate, Destination _barrier, Destination _hospital,
      string _department, string _area, string _status, string _addition, string _history, string _remarks)
    {
        FirstNameH = _firstNameH;
        LastNameH = _lastNameH;
        FirstNameA = _firstNameA;
        LastNameA = _lastNameA;
        CellPhone = _cellPhone;
        CellPhone1 = _cellPhone1;
        HomePhone = _homePhone;
        City = _city;
        Gender = _gender;
        BirthDate = _birthdate;
        Barrier = _barrier;
        Hospital = _hospital;
        Department = _department;
        LivingArea = _area;
        Status = _status;
        Addition = _addition;
        Remarks = _remarks;
        History = _history;
    }

    public int Id { get => id; set => id = value; }
    public string FirstNameH { get => firstNameH; set => firstNameH = value; }
    public string FirstNameA { get => firstNameA; set => firstNameA = value; }
    public string LastNameH { get => lastNameH; set => lastNameH = value; }
    public string LastNameA { get => lastNameA; set => lastNameA = value; }
    public string Gender { get => gender; set => gender = value; }
    public int CellPhone { get => cellPhone; set => cellPhone = value; }
    public string LivingArea { get => livingArea; set => livingArea = value; }
    public string Addition { get => addition; set => addition = value; }
    public string Status { get => status; set => status = value; }
    public string City { get => city; set => city = value; }
    public string Department { get => department; set => department = value; }
    public string History { get => history; set => history = value; }
    public Destination Barrier { get => barrier; set => barrier = value; }
    public Destination Hospital { get => hospital; set => hospital = value; }
    public int HomePhone { get => homePhone; set => homePhone = value; }
    public string DisplayName { get => displayName; set => displayName = value; }
    public string BirthDate { get => birthDate; set => birthDate = value; }
    public int CellPhone1 { get => cellPhone1; set => cellPhone1 = value; }
    public string Remarks { get => remarks; set => remarks = value; }
    public List<RidePat> RidePatList { get => ridePatList; set => ridePatList = value; }
    public List<Escorted> EscortedList { get => escortedList; set => escortedList = value; }

    public DataTable read()
    {
        DBservices dbs = new DBservices();
        dbs = dbs.ReadFromDataBase("RoadDBconnectionString", "Patient");
        return dbs.dt;
    }


    public List<Patient> getListPatient()
    {
        DBservices dbs = new DBservices();
        List<Patient> listp = new List<Patient>();
        listp = dbs.getListPatient("RoadDBconnectionString", "Patient");
        return listp;
    }

    public List<Patient> getPatientInHospitals(string hospital)
    {
        DBservices dbs = new DBservices();
        List<Patient> listp = new List<Patient>();
        listp = dbs.getPatientInHospitals("RoadDBconnectionString", "Patient", hospital );
        return listp;
    }
    
        public string getAdditionOfPatient(string displayName)
    {
        DBservices dbs = new DBservices();
        string addition;
        addition = dbs.getAdditionOfPatient("RoadDBconnectionString", "Patient", displayName);
        return addition;
    }


    public Patient gePatient(string phoneNumber)
    {
        DBservices dbs = new DBservices();
        Patient p = new Patient();
        p = dbs.getPatient("RoadDBconnectionString", "Patient", phoneNumber);
        p.RidePatList= dbs.getRideList("RoadDBconnectionString", "Patient", phoneNumber);
        p.EscortedList = dbs.getEscortedList("RoadDBconnectionString", "Patient", phoneNumber);
        return p;
    }
}
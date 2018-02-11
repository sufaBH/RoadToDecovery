using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

/// <summary>
/// Summary description for patientWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class patientWS : System.Web.Services.WebService
{

    public patientWS()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getPatients(string prefix)
    {
        Patient p = new Patient();
        List<Patient> listp = p.getListPatient();
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(listp);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getPatientInHospitals(string prefix)
    {
        Patient p = new Patient();
        List<Patient> listp = p.getPatientInHospitals(prefix);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(listp);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertpat(Patient patient)
    {
        DBservices dbs = new DBservices();
        dbs.insert(patient);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(patient);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getAdditionOfPatient(string prefix)
    {
        Patient p = new Patient();
        string add = p.getAdditionOfPatient(prefix);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(add);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string gePatient(string phoneNumber)
    {
        Patient p = new Patient();
        p = p.gePatient(phoneNumber);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(p);
        return jsonString;

    }
}

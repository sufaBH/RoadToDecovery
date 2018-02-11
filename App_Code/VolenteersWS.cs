using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

/// <summary>
/// Summary description for VolenteersWS
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class VolenteersWS : System.Web.Services.WebService
{

    public VolenteersWS()
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
    public string getUsers(string prefix)
    {
            Volunteer v = new Volunteer();
            List<Volunteer> listv = v.getList();
            JavaScriptSerializer js = new JavaScriptSerializer();
            // serialize to string
            string jsonString = js.Serialize(listv);
            return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertVol(Volunteer volunteer)
    {
        DBservices dbs = new DBservices();
        dbs.insert(volunteer);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(volunteer);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getrespList(string prefix)
    {
        Volunteer v = new Volunteer();
        List<Volunteer> listv = v.getrespList(prefix);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(listv);
        return jsonString;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string geUser(string phoneNumber)
    {
        Volunteer v = new Volunteer();
        v = v.geUser(phoneNumber);
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonString = js.Serialize(v);
        return jsonString;

    }
}

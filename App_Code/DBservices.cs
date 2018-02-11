using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for DBservices
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    public DBservices ReadFromDataBase(string conString, string tableName)
    {

        DBservices dbS = new DBservices(); // create a helper class
        SqlConnection con = null;

        try
        {
            con = dbS.connect(conString); // open the connection to the database/

            String selectStr = "SELECT * FROM " + tableName; // create the select that will be used by the adapter to select data from the DB

            SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

            DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
            da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

            DataTable dt = ds.Tables[0];

            // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
            dbS.dt = dt;
            dbS.da = da;

            return dbS;
        }
        catch (Exception ex)
        {
            // write to log
            throw ex;
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    public List<Volunteer> getList(string conString, string tableName)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Volunteer> listv = new List<Volunteer>();
            while (dr.Read())
            {
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                string cellPhone = dr["cellPhone"].ToString();
                Volunteer v = new Volunteer(firstNameH, lastNameH, cellPhone);
                listv.Add(v);
            }

            return listv;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    public Patient getPatient(string conString, string tableName, string phoneNumber)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName + " WHERE cellPhone = " + phoneNumber + " or cellPhone2 =" + phoneNumber + ";";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Patient p = new Patient();
            while (dr.Read())
            {
                string displayName = dr["displayName"].ToString();
                string firstNameA = dr["firstNameA"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                string lastNameA = dr["lastNameA"].ToString();
                string cellPhone = dr["cellPhone"].ToString();
                string cellPhone2 = dr["cellPhone2"].ToString();
                string homePhone = dr["homePhone"].ToString();
                string city = dr["city"].ToString();
                string livingArea = dr["livingArea"].ToString();
                string statusPatient = dr["statusPatient"].ToString();
                string addition = dr["addition"].ToString();
                string birthdate = dr["birthdate"].ToString();
                string history = dr["history"].ToString();
                string department = dr["department"].ToString();
                string barrier = dr["barrier"].ToString();
                string hospital = dr["hospital"].ToString();
                string gender = dr["gender"].ToString();
                string remarks = dr["remarks"].ToString();

                Destination bar = new Destination(barrier);
                Destination hos = new Destination(hospital);

             p = new Patient(displayName,firstNameH,firstNameA,lastNameH,lastNameA,Convert.ToInt32(cellPhone),Convert.ToInt32(cellPhone2),
                 Convert.ToInt16(homePhone),city,gender,birthdate,bar,hos,department,livingArea,statusPatient,addition,history,remarks);
            }


            return p;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public List<Escorted> getEscortedList(string conString, string tableName, string phoneNumber)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            

            String selectSTR = "SELECT * FROM " + tableName + " inner join Escorted on Patient.displayName=Escorted.patient or Patient.displayName=Escorted.patient1  WHERE Patient.cellPhone = " + phoneNumber + " or Patient.cellPhone2 =" + phoneNumber + ";";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Escorted> listesc = new List<Escorted>();
            while (dr.Read())
            {
                string displayName = dr["displayName"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string firstNameA = dr["firstNameA"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                string lastNameA = dr["lastNameA"].ToString();
                int cellPhone = Convert.ToInt32(dr["cellPhone"]);
                int cellPhone2 = Convert.ToInt32(dr["cellPhone2"]);
                int homePhone = Convert.ToInt32(dr["homePhone"]);
                string city = dr["city"].ToString();
                string statusEscorted = dr["statusEscorted"].ToString();
                string contactType = dr["contactType"].ToString();
                string gender = dr["gender"].ToString();

                Escorted es = new Escorted(displayName, firstNameH, firstNameA, lastNameH, lastNameA, cellPhone, cellPhone2,
                    homePhone, city, statusEscorted, contactType, gender);
                listesc.Add(es);
            }
            return listesc;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    public List<RidePat> getRideList(string conString, string tableName, string phoneNumber)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName + " inner join RidePat on Patient.displayName=RidePat.patient WHERE Patient.cellPhone = " + phoneNumber + " or Patient.cellPhone2 =" + phoneNumber + ";";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<RidePat> listRidePat = new List<RidePat>();
            while (dr.Read())
            {
                int ridePatNum = Convert.ToInt32(dr["ridePatNum"]);
                string startPlace = dr["startPlace"].ToString();
                string finishPlace = dr["finishPlace"].ToString();
                string dayRide = dr["dayRide"].ToString();
                string dateRide = dr["dateRide"].ToString();
                string hourRide = dr["hourRide"].ToString();
                int quantity = Convert.ToInt32(dr["quantity"]);
                string addition = dr["addition"].ToString();
                string rideType = dr["rideType"].ToString();
                string coordinator = dr["coordinator"].ToString();
                string remark = dr["remark"].ToString();
                string statusRidePat = dr["statusRidePat"].ToString();
                string escorted = dr["escorted"].ToString();
                string escorted1 = dr["escorted1"].ToString();
                string escorted2 = dr["escorted2"].ToString();
                Escorted es1 = new Escorted(escorted);
                Escorted es2 = new Escorted(escorted1);
                Escorted es3 = new Escorted(escorted2);
                Destination start = new Destination(startPlace);
                Destination finish = new Destination(finishPlace);
                Volunteer vol = new Volunteer(coordinator);
                RidePat rp = new RidePat(ridePatNum, es1, es2, es3, start, finish, dayRide, dateRide, hourRide, quantity, addition, rideType, vol, remark, statusRidePat);
                listRidePat.Add(rp);
            }
            return listRidePat;

            
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }
    public Volunteer getUser(string conString, string tableName, string phoneNumber)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName + " WHERE cellPhone = " + phoneNumber + " or cellPhone2 =" + phoneNumber + ";";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            Volunteer v = new Volunteer();
            while (dr.Read())
            {
                string displayName = dr["displayName"].ToString();
                string firstNameA = dr["firstNameA"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                string lastNameA = dr["lastNameA"].ToString();
                string cellPhone = dr["cellPhone"].ToString();
                string cellPhone2 = dr["cellPhone2"].ToString();
                string homePhone = dr["homePhone"].ToString();
                string city = dr["city"].ToString();
                string street = dr["street"].ToString();
                string typeVol = dr["typeVol"].ToString();
                string email = dr["email"].ToString();
                string preferDay1 = dr["preferDay1"].ToString();
                string preferHour1 = dr["preferHour1"].ToString();
                string preferDay2 = dr["preferDay2"].ToString();
                string preferHour2 = dr["preferHour2"].ToString();
                string preferDay3 = dr["preferDay3"].ToString();
                string preferHour3 = dr["preferHour3"].ToString();
                string preferRoute1 = dr["preferRoute1"].ToString();
                string preferRoute2 = dr["preferRoute2"].ToString();
                string preferRoute3 = dr["preferRoute3"].ToString();
                string joinDate = dr["joinDate"].ToString();
                string statusVolunteer = dr["statusVolunteer"].ToString();
                string knowArabic = dr["knowArabic"].ToString();
                string birthdate = dr["birthdate"].ToString();
                string gender = dr["gender"].ToString();
                v = new Volunteer(displayName,firstNameA,firstNameH,lastNameH,lastNameA, cellPhone, cellPhone2,homePhone,city,street,email,birthdate,
                    joinDate,statusVolunteer,gender,knowArabic,preferRoute1,preferRoute2,preferRoute3,preferDay1,preferDay2,preferDay3,
                    preferHour1,preferHour2,preferHour3,typeVol);
            }

            return v;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }


        public List<Volunteer> getrespList(string conString, string tableName, string typeVol)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);
            String selectSTR = "SELECT * FROM " + tableName + " where typeVol = '" + typeVol + "';";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Volunteer> listv = new List<Volunteer>();
            while (dr.Read())
            {
                string displayName = dr["displayName"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                string cellPhone = dr["cellPhone"].ToString();
                Volunteer v = new Volunteer(displayName, firstNameH, lastNameH, cellPhone);
                listv.Add(v);
            }

            return listv;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }


    public List<Patient> getListPatient(string conString, string tableName)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Patient> listp = new List<Patient>();
            while (dr.Read())
            {
                string displayName = dr["displayName"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                int cellPhone = Convert.ToInt32(dr["cellPhone"]);
                Patient p = new Patient(displayName, firstNameH, lastNameH, cellPhone);
                listp.Add(p);
            }

            return listp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    public List<Destination> getListdestination(string conString, string tableName)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName;
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Destination> listd = new List<Destination>();
            while (dr.Read())
            {
                string name = dr["name"].ToString();
                Destination d = new Destination(name);
                listd.Add(d);
            }

            return listd;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    public List<Patient> getPatientInHospitals(string conString, string tableName, string hospital)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName + " WHERE hospital =" + "'" + hospital + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Patient> listp = new List<Patient>();
            while (dr.Read())
            {
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                int cellPhone = Convert.ToInt32(dr["cellPhone"]);
                Patient p = new Patient(firstNameH, lastNameH, cellPhone);
                listp.Add(p);
            }

            return listp;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }

    public int insert(Volunteer v)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("RoadDBconnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String mStr = BuildInsertCommandVol(v);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);
        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object
        cmd.Connection = con;              // assign the connection to the command object
        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 
        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds
        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure
        return cmd;
    }

    private String BuildInsertCommandVol(Volunteer v)
    {
        String command;
        string displayName = v.FirstNameH +" "+ v.LastNameH;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}', '{11}', '{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}')",
            displayName, v.FirstNameH, v.FirstNameA, v.LastNameH, v.LastNameA,
            v.CellPhone, v.CellPhone2, v.HomePhone, v.City, v.Address,
            v.Email, v.Birthdate, v.JoinDate, v.Status, v.Gender,
            v.KnowArabic, v.PreferRoute1, v.PreferRoute2, v.PreferRoute3, v.Day1,
            v.Day2, v.Day3, v.Hour1, v.Hour2, v.Hour3, v.TypeVol);
        String prefix = "INSERT INTO Volunteer " + "(displayName, firstNameH,firstNameA, lastNameH,lastNameA, cellPhone,cellPhone2,homePhone,city,street, email,birthdate ,joinDate ,statusVolunteer,gender,knowArabic,preferRoute1,preferRoute2,preferRoute3,preferDay1,preferDay2,preferDay3,preferHour1,preferHour2,preferHour3,typeVol)";
        command = prefix + sb.ToString();
        return command;
    }

    public int insert(Patient p)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("RoadDBconnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String mStr = BuildInsertCommandpat(p);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);
        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private String BuildInsertCommandpat(Patient p)
    {
        String command;
        string displayName = p.FirstNameH +" "+ p.LastNameH;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
            displayName, p.FirstNameH, p.FirstNameA, p.LastNameH, p.LastNameA, p.CellPhone, p.CellPhone1, p.HomePhone, p.City, p.Gender, p.BirthDate, p.Barrier.Name, p.Hospital.Name, p.Department, p.LivingArea, p.Status, p.Addition, p.History, p.Remarks);
        String prefix = "INSERT INTO Patient " + "(displayName, firstNameH,firstNameA, lastNameH,lastNameA, cellPhone,cellPhone2,homePhone,city, gender,birthdate,barrier ,hospital ,department,livingArea,statusPatient,addition,history,remarks)";
        command = prefix + sb.ToString();
        return command;
    }

    public int insert(Escorted e)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("RoadDBconnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String mStr = BuildInsertCommandEsc(e);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);
        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }
    private String BuildInsertCommandEsc(Escorted e)
    {
        String command;
        string displayName = e.FirstNameH +" "+ e.LastNameH ;
        string displayNamePat = e.Pat.FirstNameH + " "+e.Pat.LastNameH;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
            displayName, e.FirstNameH, e.FirstNameA, e.LastNameH, e.LastNameA, e.CellPhone, e.CellPhone2, e.HomePhone,
            e.Addrees, e.ContactType, e.Gender, e.Status, displayNamePat);
        String prefix = "INSERT INTO Escorted " + "(displayName, firstNameH,firstNameA, lastNameH,lastNameA, cellPhone,cellPhone2,homePhone,city,contactType,gender,statusEscorted,patient)";
        command = prefix + sb.ToString();
        return command;
    }

    public int insert(Destination d)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("RoadDBconnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String mStr = BuildInsertCommanddest(d);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);
        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private String BuildInsertCommanddest(Destination d)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')",
            d.Type, d.Name, d.Area, d.Direction, d.Responsible.DisplayName, d.Status, d.Remarks, d.ManagerName, d.ManagerLastName, d.ManagerPhones, d.ManagerPhones2);
        String prefix = "INSERT INTO Destination " + "(typeDestination,name,area,direction,responsible,statusDestination,remarks,managerName,managerLastName,managerPhones1,managerPhones2)";
        command = prefix + sb.ToString();
        return command;
    }


    public List<Escorted> getListEscorted(string conString, string tableName, string displayName)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT * FROM " + tableName + " WHERE patient =" + "'" + displayName + "' or patient1 =" + "'" + displayName + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            List<Escorted> listE = new List<Escorted>();
            while (dr.Read())
            {
                string displayname = dr["displayName"].ToString();
                string firstNameH = dr["firstNameH"].ToString();
                string lastNameH = dr["lastNameH"].ToString();
                int cellPhone = Convert.ToInt32(dr["cellPhone"]);
                Escorted e = new Escorted(displayname, firstNameH, lastNameH, cellPhone);
                listE.Add(e);
            }

            return listE;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }


    public string getAdditionOfPatient(string conString, string tableName, string displayName)
    {

        SqlConnection con = null;
        try
        {
            con = connect(conString);

            String selectSTR = "SELECT addition FROM " + tableName + " WHERE displayName =" + "'" + displayName + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            string add = "";
            while (dr.Read())
            {
                add = dr["addition"].ToString();
            }

            return add;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
    public int insert(RidePat r)
    {
        SqlConnection con;
        SqlCommand cmd;
        try
        {
            con = connect("RoadDBconnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        String mStr = BuildInsertCommandRidePat(r);      // helper method to build the insert string
        cmd = CreateCommand(mStr, con);
        try
        {
            int numEffected = cmd.ExecuteNonQuery();
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }
        }
    }

    private String BuildInsertCommandRidePat(RidePat r)
    {
        String command;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')",
            r.Pat.DisplayName,r.StartPlace.Name,r.Target.Name,r.Day,r.Date,r.LeavingHour,r.Quantity,r.Addition,r.RideType,r.Coordinator.DisplayName,r.Remark,r.Status,r.Escorted1.DisplayName);
        String prefix = "INSERT INTO RidePat " + "(patient,startPlace,finishPlace,dayRide,dateRide,hourRide,quantity,addition,rideType,coordinator,remark,statusRidePat,escorted)";
        command = prefix + sb.ToString();
        return command;
    }
    
}


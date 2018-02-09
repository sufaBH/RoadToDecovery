using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Volunteer v = new Volunteer();
        List<Volunteer> listV = new List<Volunteer>();
        listV = v.getList();
        foreach (Volunteer vol in listV)
        {
            Label l = new Label();
            l.Text = vol.FirstNameH + " " + vol.LastNameH + " ";
            ph.Controls.Add(l);
        }
    }
}
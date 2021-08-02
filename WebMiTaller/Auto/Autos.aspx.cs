using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassCapaEntidades;
using ClassLogicaNegocioTaller;

namespace WebMiTaller.Auto
{
    public partial class Autos : System.Web.UI.Page
    {
     LogicaAuto objLogAuto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogAuto = new LogicaAuto();
                Session["objLogAuto"] = objLogAuto;
            }
            else
            {
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
            }

            getAutos();
        }
        public void getAutos()
        {
            string msg = "";
            GridAutos.DataSource = objLogAuto.getAutoDataSet(ref msg);
            GridAutos.DataBind();
        }
        protected void btnAddAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarAuto.aspx");
        }

        protected void btnRegresarAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void GridAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = GridAutos.SelectedRow.Cells[1].Text;
            Response.Redirect("AccionesAuto.aspx");
        }
    }
}
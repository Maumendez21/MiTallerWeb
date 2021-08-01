using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI;

using ClassLogicaNegocioTaller;

namespace WebMiTaller.Auto
{
    public partial class AgregarAuto : System.Web.UI.Page
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
        }

        protected void btnAddAuto_Click(object sender, EventArgs e)
        {
            ClassCapaEntidades.Auto temp = new ClassCapaEntidades.Auto
            {
                F_Marca = Convert.ToInt32(txtMarca.Text),
                Modelo = txtModelo.Text,
                año = txtAño.Text,
                color = txtColor.Text,
                placas = txtPlacas.Text,
                dueño = Convert.ToInt32(txtDueño.Text)
            };

            string resp = "";
            Boolean recibe = false;

            recibe = objLogAuto.InsertAuto(temp, ref resp);
            if (recibe)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "recibe1", "msgbox(`Correcto1`, `" + resp + "`, `success`)", true);
                Response.Redirect("Autos.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "recibe2", "msgbox(`Error1`, `" + resp + "`, `error`)", true);
            }
        }

        protected void btnCancelAuto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autos.aspx");
        }
    }
}
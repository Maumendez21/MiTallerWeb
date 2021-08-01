using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLogicaNegocioTaller;

namespace WebMiTaller.Auto
{
    public partial class AccionesAuto : System.Web.UI.Page
    {
        LogicaAuto objLogAuto = null;
        ClassCapaEntidades.Auto Auto = null;
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogAuto = new LogicaAuto();
                Session["objLogAuto"] = objLogAuto;
                id = Session["id"].ToString();
                cargarAuto();
            }
            else
            {
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
                id = Session["id"].ToString();
            }
        }
        public void cargarAuto()
        {
            string recibe = "";
            Auto = objLogAuto.getAutoId(id, ref recibe);
            txtModelo.Text = Auto.Modelo;
            txtAño.Text = Auto.año;
            txtColor.Text = Auto.color;
            txtPlacas.Text = Auto.placas;
        }
        protected void btnActualizarAuto_Click(object sender, EventArgs e)
        {
            ClassCapaEntidades.Auto temp = new ClassCapaEntidades.Auto
            {
                Modelo = txtModelo.Text,
                año = txtAño.Text,
                color = txtColor.Text,
                placas = txtPlacas.Text,
            };

            string resp = "";
            Boolean recibe = false;

            recibe = objLogAuto.UpdateAuto(temp, id, ref resp);
            if (recibe)
            {
                Response.Redirect("Autos.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORCLIENT", "msgbox(`Error`, `" + resp + "`, `error`)", true);
            }
        }

        protected void btnEliminarAuto_Click(object sender, EventArgs e)
        {
            string resp = "";
            Boolean recibe = false;
            recibe = objLogAuto.deleteAuto(id, ref resp);

            if (recibe)
            {
                Response.Redirect("Autos.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORdelete", "msgbox(`Error`, `" + resp + "`, `error`)", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autos.aspx");
        }
    }
}
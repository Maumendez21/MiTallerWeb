using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Librerias de clases
using ClassCapaEntidades;
using ClassLogicaNegocioTaller;

namespace WebMiTaller.Clientes
{
    public partial class AgregarCliente : System.Web.UI.Page
    {

        LogicaCliente objLogClient = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogClient = new LogicaCliente();
                Session["objLogClient"] = objLogClient;
            }
            else
            {
                objLogClient = (LogicaCliente)Session["objLogClient"];
            }
        }

        protected void btnAddCliente_Click(object sender, EventArgs e)
        {
            Cliente temp = new Cliente
            {
                Nombre = txtNombre.Text,
                ApellidoP = txtApellidoP.Text,
                ApellidoM = txtApellidoM.Text,
                Celular = txtCelular.Text,
                TelOficina = txtCelularCorpo.Text,
                Correo = txtCorreo.Text,
                CorreoCorporativo = txtCorreoCorpo.Text
            };

            string resp = "";
            Boolean recibe = false;

            recibe = objLogClient.InsertClient(temp, ref resp);
            if (recibe)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "recibe1", "msgbox(`Correcto1`, `" + resp + "`, `success`)", true);
                Response.Redirect("Clientes.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "recibe2", "msgbox(`Error1`, `" + resp + "`, `error`)", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }
    }
}
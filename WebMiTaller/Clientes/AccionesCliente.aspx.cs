using ClassCapaEntidades;
using ClassLogicaNegocioTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMiTaller.Clientes
{
    public partial class AccionesCliente : System.Web.UI.Page
    {
        LogicaCliente objLogClient = null;
        Cliente cliente = null;
        string id = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogClient = new LogicaCliente();
                Session["objLogClient"] = objLogClient;
                id = Session["id"].ToString();
                cargarCliente();
            }
            else
            {
                objLogClient = (LogicaCliente)Session["objLogClient"];
                id = Session["id"].ToString();
            }

            
        }

        public void cargarCliente()
        {
            string recibe = "";
            cliente = objLogClient.getCLientId(id, ref recibe);
            txtNombre.Text = cliente.Nombre;
            txtApellidoP.Text = cliente.ApellidoP;
            txtApellidoM.Text = cliente.ApellidoM;
            txtTelefono.Text = cliente.Celular;
            txtCorreo.Text = cliente.Correo;
            txtCorreoEmpresa.Text = cliente.CorreoCorporativo;
            txtTelefonoEmpresa.Text = cliente.TelOficina;
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente temp = new Cliente
            {
                Nombre = txtNombre.Text,
                ApellidoP = txtApellidoP.Text,
                ApellidoM = txtApellidoM.Text,
                Celular = txtTelefono.Text,
                TelOficina = txtTelefonoEmpresa.Text,
                Correo = txtCorreo.Text,
                CorreoCorporativo = txtCorreoEmpresa.Text
            };

            string resp = "";
            Boolean recibe = false;

            recibe = objLogClient.UpdateClient(temp, id, ref resp);
            if (recibe)
            {
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "SUCCESCLIENT", "msgbox(`Correcto`, `" + resp + "`, ` success`, ` Clientes.aspx` )", true);
               
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORCLIENT", "msgbox(`Error`, `" + resp + "`, `error`, ` Clientes/AccionesClientes.aspx`)", true);
            }

            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            string resp = "";
            Boolean recibe = false;
            recibe = objLogClient.deleteClient(id, ref resp);

            if (recibe)
            {
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORCLIENT", "msgbox(`Error`, `" + resp + "`, `error`)", true);
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORdelete", "msgbox(`Error`, `" + resp + "`, `error`)", true);
            }


        }
    }
}
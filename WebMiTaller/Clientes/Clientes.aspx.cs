using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLogicaNegocioTaller;

namespace WebMiTaller.Clientes
{
    public partial class Clientes : System.Web.UI.Page
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

            getClientes();
        }

        public void getClientes()
        {
            string msg = "";
            GridClientes.DataSource = objLogClient.getClientsDataSet(ref msg);
            GridClientes.DataBind();
        }

        protected void btnAddClient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void GridClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["id"] = GridClientes.SelectedRow.Cells[1].Text;
            Response.Redirect("AccionesCliente.aspx");
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

 
    }
}
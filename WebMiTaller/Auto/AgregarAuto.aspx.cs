using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLogicaNegocioTaller;
using ClassCapaEntidades;

namespace WebMiTaller.Auto
{
    public partial class AgregarAuto : System.Web.UI.Page
    {
        LogicaAuto objLogAuto = null;
        LogicaCliente objLogClient = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogAuto = new LogicaAuto();
                Session["objLogAuto"] = objLogAuto;
                objLogClient = new LogicaCliente();
                Session["objLogClient"] = objLogClient;
                cargarMarcas();
                cargarClientes();
            }
            else
            {
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
                objLogClient = (LogicaCliente)Session["objLogClient"];  
            }           
        }

        private void cargarMarcas()
        {
            List<Marca> listRecibe = null;
            string msg = "";
            listRecibe = objLogAuto.getMarcas(ref msg);

            if (listRecibe != null)
            {
                dropMarcas.Items.Clear();
                foreach (Marca item in listRecibe)
                {
                    dropMarcas.Items.Add(new ListItem(item.marca, item.idMarca.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }

        private void cargarClientes()
        {
            List<Cliente> listRecibe = null;
            string msg = "";
            listRecibe = objLogClient.getClients(ref msg);

            if (listRecibe != null)
            {
                dropClient.Items.Clear();
                foreach (Cliente item in listRecibe)
                {
                    dropClient.Items.Add(new ListItem(item.Nombre, item.id_cliente.ToString()));
                }

            }

        }

        protected void btnAddAuto_Click(object sender, EventArgs e)


        {
            ClassCapaEntidades.Auto temp = new ClassCapaEntidades.Auto
            {
                F_Marca = Convert.ToInt32(ViewState["marca"]),
                Modelo = txtModelo.Text,
                año = txtAño.Text,
                color = txtColor.Text,
                placas = txtPlacas.Text,
                dueño = Convert.ToInt32(ViewState["cliente"])
            };

            string resp = "";
            Boolean recibe = false;

            recibe = objLogAuto.InsertAuto(temp, ref resp);
            if (recibe)
            {
                ViewState["marca"] = 0;
                ViewState["cliente"] = 0;
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

        protected void dropMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ViewState["marca"] = dropMarcas.SelectedValue.ToString();
        }

        protected void dropClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ViewState["cliente"] = dropClient.SelectedValue.ToString();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
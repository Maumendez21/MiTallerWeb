using ClassCapaEntidades;
using ClassLogicaNegocioTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMiTaller.Revisiones
{

    public partial class RealizarRevision : System.Web.UI.Page
    {
        LogicaAuto objLogAuto = null;
        LogicaCliente objLogClient = null;
        LogicaMecanicos objLogMecanic = null;
        LogicaRevision objLogRev = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogAuto = new LogicaAuto();
                Session["objLogAuto"] = objLogAuto;

                objLogClient = new LogicaCliente();
                Session["objLogClient"] = objLogClient;

                objLogMecanic = new LogicaMecanicos();
                Session["objLogMecanic"] = objLogMecanic;
                
                objLogRev = new LogicaRevision();
                Session["objLogRev"] = objLogRev;

                cargarMarcas();
                cargarClientes();
                cargarMecanicos();
            }
            else
            {
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
                objLogClient = (LogicaCliente)Session["objLogClient"];
                objLogMecanic = (LogicaMecanicos)Session["objLogMecanic"];
                objLogRev = (LogicaRevision)Session["objLogRev"];
            }
        }

        private void cargarMecanicos()
        {
            List<ClassCapaEntidades.Mecanico> listRecibe = null;
            string msg = "";
            listRecibe = objLogMecanic.getAllMechanics(ref msg);

            if (listRecibe != null)
            {
                dropMecanico.Items.Clear();
                dropMecanico.Items.Add(new ListItem("Selecciona un Técnico", "0"));
                foreach (ClassCapaEntidades.Mecanico item in listRecibe)
                {
                    dropMecanico.Items.Add(new ListItem(item.Nombre, item.id_Tecnico.ToString()));
                }

            }
        }

        private void cargarMarcas()
        {
            List<Marca> listRecibe = null;
            string msg = "";
            listRecibe = objLogAuto.getMarcas(ref msg);

            if (listRecibe != null)
            {
                dropMarca.Items.Clear();
                dropMarca.Items.Add(new ListItem("Selecciona una marca", "0"));
                foreach (Marca item in listRecibe)
                {
                    dropMarca.Items.Add(new ListItem(item.marca, item.idMarca.ToString()));
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
                dropCliente.Items.Clear();
                dropCliente.Items.Add(new ListItem("Selecciona el dueño", "0"));
                foreach (Cliente item in listRecibe)
                {
                    dropCliente.Items.Add(new ListItem(item.Nombre, item.id_cliente.ToString()));
                }

            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Index.aspx");
        }

        protected void btnRealizar_Click(object sender, EventArgs e)
        {
            int recibeId;
            string msg = "";
            
            
            if (insertarAuto(ref msg))
            {
                recibeId = objLogAuto.devuelveUltimoId(ref msg);
                if (recibeId != 0)
                {
                    if (revision(recibeId, ref msg))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "revision", "msgboxS(`Correcto`, `" + msg + "`, `success`,  `../index.aspx`)", true);
                       
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "errorRev", "msgboxS(`Error`, `" + msg + "`, `error`, `../index.aspx` )", true);
                    }
                }
            }


        }
        
        private Boolean insertarAuto(ref string msg)
        {
            ClassCapaEntidades.Auto temp = new ClassCapaEntidades.Auto
            {
                F_Marca = Convert.ToInt32(ViewState["marca"]),
                Modelo = txtModelo.Text,
                año = txtAño.Text,
                color = txtColor.Text,
                placas = txtPlaca.Text,
                dueño = Convert.ToInt32(ViewState["cliente"])
            };

            
            return objLogAuto.InsertAuto(temp, ref msg);
        }

        private Boolean revision(int idAuto, ref string msg)
        {
            Revision temp = new Revision
            {
                entrada = DateTime.Now,
                falla = txtFalla.Text,
                diagnostico = txtDiagnostico.Text,
                autorizacion = false,
                auto = idAuto,
                mecanico = Convert.ToInt32(ViewState["mecanico"])
            };
            return objLogRev.newRevision(temp, ref msg);
        }

        protected void dropMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["marca"] = dropMarca.SelectedValue.ToString();
        }

        protected void dropCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["cliente"] = dropCliente.SelectedValue.ToString();
        }

        protected void dropMecanico_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["mecanico"] = dropMecanico.SelectedValue.ToString();
        }
    }
}
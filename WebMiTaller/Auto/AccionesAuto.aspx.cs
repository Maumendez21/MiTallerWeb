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
                cargarMarcas();

                cargarRevisiones();
                cargarReparaciones();
            }
            else
            {
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
                id = Session["id"].ToString();
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
                foreach (Marca item in listRecibe)
                {
                    dropMarca.Items.Add(new ListItem(item.marca, item.idMarca.ToString()));
                }
                //dropMarcas.Items.Add(new ListItem("Selecciona una marca", "0",));

            }
        }

        private void cargarRevisiones()
        {
            string msg = "";
            gridRevisiones.DataSource = objLogAuto.getRevisionesAutoSet(id, ref msg);
            gridRevisiones.DataBind();
        }
        private void cargarReparaciones()
        {
            string msg = "";
            gridReparaciones.DataSource = objLogAuto.getReparacionesAutoSet(id, ref msg);
            gridReparaciones.DataBind();
        }
        public void cargarAuto()
        {
            string recibe = "";
            Auto = objLogAuto.getAutoId(id, ref recibe);
            dropMarca.SelectedIndex = Auto.F_Marca;
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "successUpdate", "msgboxS(`Actualizadp`, `" + resp + "`, `success`, ` Autos.aspx`)", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORCLIENT", "msgboxS(`Error`, `" + resp + "`, `error`,  ` AccionesAuto.aspx`)", true);
            }
        }

        protected void btnEliminarAuto_Click(object sender, EventArgs e)
        {
            string resp = "";
            Boolean recibe = false;
            recibe = objLogAuto.deleteAuto(id, ref resp);

            if (recibe)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "success", "msgboxS(`Correct`, `" + resp + "`, `success`, ` Autos.aspx`)", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "errrrr", "msgboxS(`Error`, `No se puede eliminar. Tal vez el auto esta en una revisión :/`, `error`, ` AccionesAuto.aspx`)", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Autos.aspx");
        }

        protected void dropMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["marca"] = dropMarca.SelectedValue.ToString();
        }

        protected void gridRevisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["FK_Revision"] = gridRevisiones.SelectedRow.Cells[1].Text;

            Response.Redirect("../Reparaciones/DetalleReparacion.aspx");
        }

        protected void gridReparaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = "";
            DateTime output;
            int garanty, id_Reparacion = 0;

            Reparacion rp = null;
            id_Reparacion = Convert.ToInt32(gridReparaciones.SelectedRow.Cells[1].Text);
            rp = objLogAuto.getReparacionT(id_Reparacion, ref message);
          
            if (rp != null)
            {
                garanty = (Convert.ToInt32(rp.Garantia) * 30);
                output = rp.salida.AddDays(garanty);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correcto", "msgboxS(`Periodo de garantia valida hasta: `, `" + output.ToString() + "`, `success`, `AccionesAuto.aspx` )", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORdelete", "msgboxS(`Error`, `Oh,oh! error inesperado :(`, `error`), `AccionesAuto.aspx`", true);
            }
        }
    }
}
using ClassLogicaNegocioTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassCapaEntidades;

namespace WebMiTaller
{
    public partial class Index : System.Web.UI.Page
    {
        LogicaRevision objLogRev = null;
        LogicaReparacion objLogRep = null;
        LogicaAuto objLogAuto = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogRev = new LogicaRevision();
                Session["objLogRev"] = objLogRev;
                objLogRep = new LogicaReparacion();
                Session["objLogRep"] = objLogRep;
                objLogAuto = new LogicaAuto();
                Session["objLogAuto"] = objLogAuto;
                cargarRevisiones();
            }
            else
            {
                objLogRev = (LogicaRevision)Session["objLogRev"];
                objLogRep = (LogicaReparacion)Session["objLogRep"];
                objLogAuto = (LogicaAuto)Session["objLogAuto"];
            }
            cargarReparaciones();
        }
        private void cargarRevisiones()
        {
            string msg = "";
            gridRevisiones.DataSource = objLogRev.getRevisionDataSet(ref msg);
            gridRevisiones.DataBind();
        }
        private void cargarReparaciones()
        {
            string msg = "";
            GridReparacion.DataSource = objLogRep.getReparacion(ref msg);
            GridReparacion.DataBind();
        }


        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Revisiones/RealizarRevision.aspx");
        }

        protected void gridRevisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se redirije a detalle de la reparación para poder autorizar la revisión
            Session["FK_Revision"] = gridRevisiones.SelectedRow.Cells[1].Text;
            
            Response.Redirect("Reparaciones/DetalleReparacion.aspx");
        }

        protected void GridReparacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string message = "";
            DateTime output;
            int garanty, id_Reparacion = 0;

            Reparacion rp = null;
            id_Reparacion = Convert.ToInt32(GridReparacion.SelectedRow.Cells[1].Text);
            rp = objLogAuto.getReparacionT(id_Reparacion, ref message);

            if (rp != null)
            {
                garanty = (Convert.ToInt32(rp.Garantia) * 30);
                output = rp.salida.AddDays(garanty);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Correcto", "msgboxS(`Periodo de garantia valida hasta: `, `" + output.ToString() + "`, `success`, `Index.aspx` )", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORdelete", "msgboxS(`Error`, `Oh,oh! error inesperado :(`, `error`), `Index.aspx`", true);
            }
        }
    }
}
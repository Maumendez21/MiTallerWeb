using ClassLogicaNegocioTaller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebMiTaller
{
    public partial class Index : System.Web.UI.Page
    {
        LogicaRevision objLogRev = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                objLogRev = new LogicaRevision();
                Session["objLogRev"] = objLogRev;
                cargarRevisiones();
            }
            else
            {
                objLogRev = (LogicaRevision)Session["objLogRev"];
            }
            
        }
        
        private void cargarRevisiones()
        {
            string msg = "";
            gridRevisiones.DataSource = objLogRev.getRevisionDataSet(ref msg);
            gridRevisiones.DataBind();
        }

        protected void btnClientes_Click(object sender, EventArgs e)
        {
            Response.Redirect("Revisiones/RealizarRevision.aspx");
        }

        protected void gridRevisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Se redirije a detalle de la revisión para poder autorizar la revisión
        }
    }
}
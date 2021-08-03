using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLogicaNegocioTaller;
using ClassCapaEntidades;

namespace WebMiTaller.Reparaciones
{
    public partial class DetalleReparacion : System.Web.UI.Page
    {

        //Referencias y variables locales
        LogicaReparacion _lgRep = null;
        LogicaRevision _lgRev = null;
        
        string id = "";
        DateTime fecha;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                _lgRep = new LogicaReparacion();
                _lgRev = new LogicaRevision();
                Session["lgRep"] = _lgRep;
                Session["lgRev"] = _lgRev;
                id = (string)Session["FK_Revision"];
                fecha = DateTime.Now;
                txtFecha.Text = fecha.ToString();  
                getRevisionID();
            }
            else
            {
                _lgRep = (LogicaReparacion)Session["lgRep"];
                _lgRev = (LogicaRevision)Session["lgRev"];
                fecha = DateTime.Now;
                txtFecha.Text = fecha.ToString();
                id = (string)Session["FK_Revision"];

            }

        }

        //Metodo auxiliar para cargar los datos de la Revisión del auto seleccionado
        public void getRevisionID()
        {
            string resp = "";
            gridDetailRev.DataSource = _lgRev.getAllDetailRev(ref resp, id);
            gridDetailRev.DataBind();

        
        }

        protected void btnRR_Click(object sender, EventArgs e)
        {
            //Variables locales e inicialización
            string message = "";
            Boolean out_ = false;
            Boolean flag = false;
            int idRev = Convert.ToInt32(Session["FK_Revision"]); 

            //Hacemos un objeto auxliar para poder insertar la reparación
            Reparacion aux = new Reparacion
            {
                Detalles = txtDetail.Text,
                Garantia = (string)ViewState["garanty"],
                salida = fecha,
                FK_Revision = idRev
            };
            //Mandamos la respuesta de la logica a nuestra variable local out_ y dependiendo de la
            //respueta validamos
            out_ = _lgRep.InsertFixCar(aux, ref message);
            //Validamos
            if (out_)
            {
                flag = _lgRev.UpdateAuth(out_, ref message, id);
                if (flag)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "reparacionT", "msgboxS(`Correcto`, `" + message + "`, `success`,  `../index.aspx`)", true);
                    Response.Redirect("../index.aspx");

                }
            }
            else
            {
                //En caso contrario mandamos un mensaje de error 
                Page.ClientScript.RegisterStartupScript(this.GetType(), "reparacionF", "msgboxS(`Error`, `" + message + "`, `error`, `../index.aspx` )", true);      
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Regresamos al inicio de la pagina de Mecanicos
            Response.Redirect("../index.aspx");
        }

        protected void txtGarantia_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["garanty"] = txtGarantia.SelectedValue.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassCapaEntidades;
using ClassLogicaNegocioTaller;

namespace WebMiTaller.Mecanico
{
    public partial class agregaTecnico : System.Web.UI.Page
    {
        //Referencia logica de negocios Mecanicos.
        LogicaMecanicos LGMCH = null;


        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación del PostBack
            if (IsPostBack == false)
            {
                LGMCH = new LogicaMecanicos();
                Session["LGM"] = LGMCH;
            }
            else
            {
                LGMCH = (LogicaMecanicos)Session["LGM"];
            }

        }

        protected void btnAddM_Click(object sender, EventArgs e)
        {
            //Variables Locales
            string _mssg = "";
            Boolean flg = false;

            //Objeto Mecanico Auxiliar para poder hacer la inserción del Mecanico nuevo.
            ClassCapaEntidades.Mecanico aux = new ClassCapaEntidades.Mecanico
            {
                Nombre = txtNombre.Text,
                App = txtApellidoP.Text,
                Apm = txtApellidoM.Text,
                Celular = txtCelular.Text,
                correo = txtCorreo.Text
            };
            //Mandamos la respuesta de la logica a nuestra variable local flg y dependiendo de la
            //respueta validamos
            flg = LGMCH.InsertMechanic(aux, ref _mssg);

            //En caso verdadero lanzamos un mensajer de que la inserción fue correcta y regresamos a la pagina de inicio
            //de Mecanicos
            if (flg)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RESPONSETRUE", "msgbox(`Correcto1`, `" + _mssg + "`, `success`)", true);
                Response.Redirect("Mecanico.aspx");
            }
            else
            {
                //En caso contrario mandamos un mensaje de error 
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RESPONSEERROR", "msgbox(`Error1`, `" + _mssg + "`, `error`)", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Regresamos al inicio de la pagina de Mecanicos
            Response.Redirect("Mecanico.aspx");
        }
    }
}
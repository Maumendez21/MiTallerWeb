using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassLogicaNegocioTaller;

namespace WebMiTaller.Mecanico
{
    public partial class Mecanico : System.Web.UI.Page
    {
        //Referencia de la logica de negocio
        LogicaMecanicos lgMechhanic = null;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Variable local
            string message = "";
            //Validación del PostBack
            if (IsPostBack == false)
            {
                lgMechhanic = new LogicaMecanicos();
                Session["MechLG"] = lgMechhanic;
            }
            else
            {
                lgMechhanic = (LogicaMecanicos)Session["MechLG"];
            }

            GridVMechanic.DataSource = lgMechhanic.getAllMechanics(ref message);
            GridVMechanic.DataBind();

        }

        protected void GridVMechanic_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["idTecnico"] = GridVMechanic.SelectedRow.Cells[1].Text;
            Response.Redirect("VerMecanico.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void btnAddMech_Click(object sender, EventArgs e)
        {
            Response.Redirect("agregaTecnico.aspx");
        }
    }
}
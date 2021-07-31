﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ClassCapaEntidades;
using ClassLogicaNegocioTaller;


namespace WebMiTaller.Mecanico
{
    public partial class VerMecanico : System.Web.UI.Page
    {
        //Referencia a la logica de negocio
        LogicaMecanicos lgM = null;
        //Objeto del tipo: Mecanico, a utilizar para eliminar o actualizar
        ClassCapaEntidades.Mecanico mecha_ = null;
        //Variable para almacenar id
        string id_Tecnico = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            //Validación del PostBack
            if (IsPostBack == false)
            {
                lgM = new LogicaMecanicos();
                Session["lgMC"] = lgM;
                id_Tecnico = (string)Session["idTecnico"];
                getClientID();
            }
            else
            {
                lgM = (LogicaMecanicos)Session["lgMC"];
                id_Tecnico = (string)Session["idTecnico"];
            }
        }

        //Metodo axulixar para no sobrecargar el pageLoad de mucho codigo.
        public void getClientID()
        {
            //Variable local
            string message = "";
            mecha_ = lgM.getMechanicID(id_Tecnico, ref message);
            txtNombre.Text = mecha_.Nombre;
            txtApellidoP.Text = mecha_.App;
            txtApellidoM.Text = mecha_.Apm;
            txtTelefono.Text = mecha_.Celular;
            txtCorreo.Text = mecha_.correo;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("../index.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Variabls locales
            string mssg = "";
            Boolean flag = false;

            //Creamos un objeto como axuliar para el momento en el cual se haga un actualización
            //ó eliminación del Mecanico seleccionado
            ClassCapaEntidades.Mecanico auxiliary = new ClassCapaEntidades.Mecanico
            {
                Nombre = txtNombre.Text,
                App = txtApellidoP.Text,
                Apm = txtApellidoM.Text,
                Celular = txtTelefono.Text,
                correo = txtCorreo.Text
            };


            //Cambiamos el status de nuestra bandera segun sea el caso ya sea verdadero o falso
            flag = lgM.updateMechanic(auxiliary, ref mssg, id_Tecnico);

            //Si la respuesta fue Verdadera(True) Regresamos a la pangina principal de Mecanicos donde veremos 
            //Reflejado el nuevo registro en nuestro control GridView
            if (flag)
            {
                Response.Redirect("Mecanico.aspx");
            }
            else
            {
                //En casso contrario mandaremos un mensaje de alerta de SweetAlert con el error cometido por el usuario

                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORUPDATE", "msgbox(`Error`, `" + mssg + "`, `error`)", true);
            }



        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Variables locales
            string message_ = "";
            Boolean flag_ = false;

            //Recibimos la respuesta en nuestra variable flag_
            flag_ = lgM.deleteMechanic(id_Tecnico, ref message_);
            //Validamos si la respuesta es verdadera, procedemos a enviar a la pagina de inicio de Mecanicos
            //Y se vere reflejado el cambio en nuestro control GridView
            if (flag_)
            {
                Response.Redirect("Mecanico.aspx");
            }
            else
            {
                //En caso contrario, mandaremos un mensaje de alerta de SweetAlert con el error cometido por el usuario
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ERRORDELETE", "msgbox(`Error`, `" + message_ + "`, `error`)", true);
            }

        }
    }
}
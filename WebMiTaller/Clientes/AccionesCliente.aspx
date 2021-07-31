﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccionesCliente.aspx.cs" Inherits="WebMiTaller.Clientes.AccionesCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<link rel="stylesheet" href="../css/sweetalert2.min.css" />
<script src="../js/sweetalert2.all.min.js" ></script>
<script src="../js/index.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

        <nav class="navbar navbar-dark bg-dark">
         <div class="container-fluid">
           <a class="navbar-brand" href="../index.aspx">
        <img src="/images/logo.png" alt="" width="110" height="60">
    </a>
         </div>
        </nav>

    <form id="form1" class="container" runat="server">
        <div class="row" >
            <div class="col-md-6 mt-4" >

             <asp:Button CssClass="btn btn-danger" ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
            </div>
        </div>
        <div class="row ">
            <div class="col-md-6" >
                Nombre: 
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                Apellido Paterno: 
                <asp:TextBox CssClass="form-control" ID="txtApellidoP" runat="server"></asp:TextBox>
                Apellido Materno:
                <asp:TextBox CssClass="form-control" ID="txtApellidoM" runat="server"></asp:TextBox>
                Telefono: 
                <asp:TextBox CssClass="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                Correo: 
                <asp:TextBox CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
                Telefono Empresa:
                <asp:TextBox CssClass="form-control" ID="txtTelefonoEmpresa" runat="server"></asp:TextBox>
                Correo Empresa: 
                <asp:TextBox CssClass="form-control" ID="txtCorreoEmpresa" runat="server"></asp:TextBox>

            </div>
            <div class="col-md-6" >
                <h4>Acciones: </h4>
                <asp:Button CssClass="btn btn-primary m-2" ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
                <asp:Button CssClass="btn btn-danger m-2" ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />   
            </div>
        </div>

        <div class="row" >
            <div class="col-md-12" >
                <h3>Autos</h3>
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>
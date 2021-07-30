<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="WebMiTaller.Clientes.AgregarCliente" %>

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
          <span class="navbar-brand" href="../index.aspx">Mi Taller</span>
          <span>Clientes</span>
         </div>
    </nav>
    <form id="form1" class="container" runat="server">
        <div class="row mt-4">
                <asp:Label ID="Label1" runat="server" Text="Si los autos  del cliente son de un corporativo o una empresa proporcionar Correo y Telefono de la Empresa en lugar del personal."></asp:Label>
            <div class="col-md-12" >

                Nombre: 
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                Apellido Paterno: 
                <asp:TextBox CssClass="form-control" ID="txtApellidoP" runat="server"></asp:TextBox>
                Apellido Materno:
                <asp:TextBox CssClass="form-control" ID="txtApellidoM" runat="server"></asp:TextBox>
                Telefono Personal: 
                <asp:TextBox  CssClass="form-control" ID="txtCelular" runat="server"></asp:TextBox>
                Correo: 
                <asp:TextBox  CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
                Telefono Empresa: 
                <asp:TextBox  CssClass="form-control" ID="txtCelularCorpo" runat="server"></asp:TextBox>
                Correo Empresa: 
                <asp:TextBox  CssClass="form-control" ID="txtCorreoCorpo" runat="server"></asp:TextBox>

                <asp:Button CssClass="btn btn-primary mt-3 mb-3" ID="btnAddCliente" runat="server" Text="Agregar" OnClick="btnAddCliente_Click" />
                <asp:Button CssClass="btn btn-danger mt-3 mb-3" ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click" />


            </div>
        </div>
    </form>

      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

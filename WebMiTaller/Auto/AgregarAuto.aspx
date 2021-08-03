<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarAuto.aspx.cs" Inherits="WebMiTaller.Auto.AgregarAuto" %>

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
  
     <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
  <div class="container-fluid" style="font-size: 20px;">
    <a class="navbar-brand m-1" href="../index.aspx">
        <img class="ms-4" src="/images/logo.png" alt="" width="110" height="60"> 
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse"  id="navbarNav">
      <ul class="navbar-nav ms-4" >
        <li class="nav-item">
          <a class="nav-link" href="../Clientes/Clientes.aspx">Clientes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Autos.aspx">Autos</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="../Mecanico/Mecanico.aspx">Mecanicos</a>
        </li>
      </ul>
    </div>
       <span class="navbar-text" style="font-weight:bold; font-style:italic; color=: white !important;">
  
           <p class="card-text text-white">Tu taller de confianza!</p>

      </span>
  </div>
    </nav>

    <form id="form1" class="container" runat="server">
        <div class="row mt-4">
                <asp:Label ID="Label1" runat="server" Text="Inserta todos los campos para agregar un nuevo Automovil."></asp:Label>
            <div class="col-md-12" >
                Marca: 
                <%--<asp:TextBox  CssClass="form-control" ID="txtMarca" runat="server"></asp:TextBox>--%>
                <asp:DropDownList CssClass="form-select" ID="dropMarcas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropMarcas_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Value="0">Selecciona una marca</asp:ListItem>
                </asp:DropDownList>
                Modelo: 
                <asp:TextBox CssClass="form-control" ID="txtModelo" runat="server"></asp:TextBox>
                Año: 
                <asp:TextBox CssClass="form-control" ID="txtAño" runat="server"></asp:TextBox>
                Color:
                <asp:TextBox CssClass="form-control" ID="txtColor" runat="server"></asp:TextBox>
                Placa: 
                <asp:TextBox  CssClass="form-control" ID="txtPlacas" runat="server"></asp:TextBox>
                Dueño 
                <%--<asp:TextBox  CssClass="form-control" ID="txtDueño" runat="server"></asp:TextBox>--%>
                <asp:DropDownList CssClass="form-select" ID="dropClient" runat="server" OnSelectedIndexChanged="dropClient_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
               
                <asp:Button CssClass="btn btn-primary mt-3 mb-3" ID="btnAddAuto" runat="server" Text="Agregar" OnClick="btnAddAuto_Click" />
                <asp:Button CssClass="btn btn-danger mt-3 mb-3" ID="btnCancelAuto" runat="server" Text="Cancelar" OnClick="btnCancelAuto_Click" />

            </div>
        </div>
    </form>

      <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

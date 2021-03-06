<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregaTecnico.aspx.cs" Inherits="WebMiTaller.Mecanico.agregaTecnico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<link rel="stylesheet" href="../css/sweetalert2.min.css" />
<script src="../js/sweetalert2.all.min" ></script>
<script src="../js/indexj.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

    <style>
    .nav-link 
    {
    color: white !important;
    }

</style>
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
          <a class="nav-link" href="#">Autos</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="Mecanico.aspx">Mecanicos</a>
        </li>
      </ul>
    </div>
       <span class="navbar-text" style="font-weight:bold; font-style:italic; color=: white !important;">
  
           <p class="card-text text-white">Tu taller de confianza!</p>

      </span>
  </div>
    </nav>


    <form id="form1" runat="server" class="container">
      
        <div class="row mt-3">
            <h4>Registrar Mecanico</h4>
            <p>En este apartado podras realizar el registro de los mecanicos</p>
             <div class="col-md-6 mt-1" >
            <div class="card text-center">
  <div class="card-header">
    <h4>Información del Mecanico</h4>
  </div>
  <div class="card-body">
                <label for="txtNombre" style="font-weight: bold">Nombre:</label>
                <asp:TextBox CssClass="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                <label for="txtApellidoP" style="font-weight: bold">Apellido Paterno:</label>
                <asp:TextBox CssClass="form-control" ID="txtApellidoP" runat="server"></asp:TextBox>
                <label for="txtApellidoM" style="font-weight: bold">Apellido Materno:</label>
                <asp:TextBox CssClass="form-control" ID="txtApellidoM" runat="server"></asp:TextBox>
                <label for="txtTelefono" style="font-weight: bold">Telefono:</label>
                <asp:TextBox  CssClass="form-control" ID="txtCelular" runat="server"></asp:TextBox>
               <label for="txtCorreo" style="font-weight: bold">Correo Electronico:</label>
                <asp:TextBox  CssClass="form-control" ID="txtCorreo" runat="server"></asp:TextBox>

  </div>
  <div class="card-footer text-muted">
    Recuerda no dejar recuadros vacíos
  </div>
</div>


</div>
            <div class="col-md-6 mt-1" >
                <div class="card text-center">
    <div class="card-header">
    <h4>Acciones</h4>
    </div>
    <div class="card-body">
  <asp:Button CssClass="btn btn-primary mt-3 mb-3" ID="btnAddM" runat="server" Text="Agregar" OnClick="btnAddM_Click" />
                <asp:Button CssClass="btn btn-danger mt-3 mb-3" ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click"  />
               
  </div>
  <div class="card-footer text-muted">
    Estas acciones no podran anularse una vez realizadas
  </div>
</div>
</div>
        </div>



    </form>

<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

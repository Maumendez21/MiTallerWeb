<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RealizarRevision.aspx.cs" Inherits="WebMiTaller.Revisiones.RealizarRevision" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
<link rel="stylesheet" href="../css/sweetalert2.min.css" />
<script src="../js/sweetalert2.all.min.js" ></script>
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
          <a class="nav-link" href="../Auto/Autos.aspx">Autos</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="../Mecanico/Mecanico.aspx">Mecanicos</a>
        </li>
      </ul>
    </div>
  </div>
    </nav>


    <form id="form1" class="container" runat="server">
        <div class="row mt-4">
            <h4>Iniciar Revisión</h4>

            <div class="col-md-4" >
                <p style="color: red">Si no existe el carro, registralo aquí.</p>
                <div class="card text-center">
                    <div class="card-header">
                    <h4>Registrar Auto</h4>
                    </div>
                    <div class="card-body">
                       Marca:
                       <asp:DropDownList CssClass="form-select" ID="dropMarca" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropMarca_SelectedIndexChanged"></asp:DropDownList>
                       Modelo: 
                       <asp:TextBox CssClass="form-control" ID="txtModelo" runat="server"></asp:TextBox>
                        Año: 
                        <asp:TextBox CssClass="form-control" ID="txtAño" runat="server"></asp:TextBox>
                        Color: 
                        <asp:TextBox CssClass="form-control" ID="txtColor" runat="server"></asp:TextBox>
                        Placa: 
                        <asp:TextBox CssClass="form-control" ID="txtPlaca" runat="server"></asp:TextBox>
                        Dueño:
                        <asp:DropDownList CssClass="form-select" ID="dropCliente" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropCliente_SelectedIndexChanged"></asp:DropDownList>
                        <a href="../Clientes/AgregarCliente.aspx" >Si el cliente es nuevo registralo aquí.</a>
                    </div>
                     <div class="card-footer text-muted">
                         Si vas a seleccionar un auto ya existente omite este formulario.
                    </div>
                </div>
            </div>

            <div class="col-md-4" >
                <p style="color: red">Si ya existe el carro seleccionalo.</p>
                <div class="card text-center">
                    <div class="card-header">
                        <h4>Seleccionar Auto</h4>
                    </div>
                    <div class="card-body">
                        Auto:
                        <asp:DropDownList CssClass="form-select" ID="dropAutos" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropAutos_SelectedIndexChanged"></asp:DropDownList>
                    </div>
                     <div class="card-footer text-muted">
                        Si vas a registrar el carro omite este formulario.
                    </div>
                </div>

            </div>

            <div class="col-md-4 mt-1" >
                <div class="card text-center">
                    <div class="card-header">
                    <h4>Revisión</h4>
                    </div>
                    <div class="card-body">
                       Falla:
                        <asp:TextBox CssClass="form-control" ID="txtFalla" runat="server" Height="53px"></asp:TextBox>

                        Diagnostico:
                        <asp:TextBox CssClass="form-control" ID="txtDiagnostico" runat="server" Height="53px"></asp:TextBox>
                        Mecanico:
                        <asp:DropDownList CssClass="form-select" ID="dropMecanico" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dropMecanico_SelectedIndexChanged"></asp:DropDownList>
                  </div>
                  <div class="card-footer text-muted">
                    Recuerda no dejar recuadros vacíos
                  </div>
                </div>
          </div>

        </div>


        <div class="row mt-4">
            <div class="col-md-12"> 
                 <div class="card text-center">
                    <div class="card-header">
                    <h4>Acciones</h4>
                    </div>
                    <div class="card-body">
                        <asp:Button CssClass="btn btn-primary mt-3 mb-3" ID="Revi" runat="server" Text="Realizar Revisión" OnClick="Revi_Click"  />
                        <asp:Button CssClass="btn btn-danger mt-3 mb-3" ID="Button2" runat="server" Text="Cancelar"  />
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

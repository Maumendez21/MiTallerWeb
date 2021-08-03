<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleReparacion.aspx.cs" Inherits="WebMiTaller.Reparaciones.DetalleReparacion" %>

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
          <a class="nav-link" href="../Auto/Autos.aspx">Autos</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="../Mecanico/Mecanico.aspx">Mecanicos</a>
        </li>
      </ul>
    </div>
  </div>
    </nav>


    <form id="form1"  class="container" runat="server">
        <div class="row mt-3">
            <h4>Detalles de Revisión</h4>
            <p>En este apartado podras consultar la información y detalle de la revisión del auto</p>
                    <div class="col-md-12">
                         <div class="card text-center">
                            <div class="card-header">
                             <h4>Detalle de Revisión del Auto seleccionado</h4>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="gridDetailRev" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1087px">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
               
                             </div>
                          <div class="card-footer text-muted">
                            Información de la Revisión.
                          </div>
                        </div>
                    </div>
                </div>

                <div class="row mt-3">
                    <p style="color:red;">Si desea continuar y dar de alta la reparación del auto rellene el siguiente formulario: </p>
                    <div class="col-md-12" >

                <div class="card text-center">
    <div class="card-header">
    <h4>Autorizar Reparación</h4>
    </div>
    <div class="card-body">

                <label for="txtDetalles" style="font-weight: bold">Detalles:</label>
                <asp:TextBox CssClass="form-control" ID="txtDetail" runat="server"></asp:TextBox>
                <label for="txtGarantia" style="font-weight: bold">Garantía (meses):</label>
                <asp:DropDownList CssClass="form-select" ID="txtGarantia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="txtGarantia_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <label for="dateSalida" style="font-weight: bold">Fecha de Entrega:</label>
                <asp:TextBox CssClass="form-control" ID="txtFecha" runat="server" style="color:red" ReadOnly="True"></asp:TextBox>
                

              


     <asp:Button CssClass="btn btn-primary m-2" ID="btnRR" runat="server" Text="Registrar Reparación Completada" OnClick="btnRR_Click"  />
     <asp:Button CssClass="btn btn-danger m-2" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />   
                  
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

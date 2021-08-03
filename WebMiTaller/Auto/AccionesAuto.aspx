<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccionesAuto.aspx.cs" Inherits="WebMiTaller.Auto.AccionesAuto" %>

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
  </div>
    </nav>

    <form id="form1" class="container" runat="server">
        <div class="row" >
            <div class="col-md-6 mt-4" >

             <asp:Button CssClass="btn btn-danger" ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-md-6" >

                <div class="card text-center">
                    <div class="card-header">
                    <h4>Auto</h4>
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
                        Placas: 
                        <asp:TextBox CssClass="form-control" ID="txtPlacas" runat="server"></asp:TextBox>
                    </div>
                    <div class="card-footer text-muted">
                    Recuerda no dejar recuadros vacíos
                  </div>
                </div>
            </div>
            <div class="col-md-6" >

                <div class="card text-center" >
                    <div class="card-header" >
                        <h4>Acciones</h4>
                    </div>
                    <div class="card-body" >
                        <asp:Button CssClass="btn btn-primary m-2" ID="btnActualizarAuto" runat="server" Text="Actualizar" OnClick="btnActualizarAuto_Click" />
                        <asp:Button CssClass="btn btn-danger m-2" ID="btnEliminarAuto" runat="server" Text="Eliminar" OnClick="btnEliminarAuto_Click" />   
                    </div>
                    <div class="card-footer text-muted">
                    Estas acciones no podran anularse una vez realizadas
                  </div>
                </div>
                
            </div>
        </div>

        <div class="row mt-4" >
            <div class="col-md-12" >
                <div class="card text-center" >
                    <div class="card-header" >
                        <h4>Revisiones activas</h4>
                    </div>
                    <div class="card-body" >
                        <asp:GridView  CssClass="form-control" ID="gridRevisiones" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridRevisiones_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:CommandField SelectText="Ver Revision" ShowSelectButton="True" />
                            </Columns>
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
                    Revisiones.
                  </div>
                </div>
                
            </div>
        </div>

        <div class="row mt-4 mb-5" >
            <div class="col-md-12" >
                <div class="card text-center" >
                    <div class="card-header" >
                        <h4>Reparaciones realizadas</h4>
                    </div>
                    <div class="card-body" >
                        <asp:GridView CssClass="form-control" ID="gridReparaciones" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gridReparaciones_SelectedIndexChanged">
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
                            <Columns>
                                <asp:CommandField SelectText="Consultar Periodo de Garantía" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="card-footer text-muted">
                    Revisiones.
                  </div>
                </div>
                
            </div>
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

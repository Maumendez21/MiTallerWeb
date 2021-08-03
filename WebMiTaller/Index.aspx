<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WebMiTaller.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="../css/sweetalert2.min.css" />
<script src="../js/sweetalert2.all.min.js" ></script>
<script src="../js/indexj.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <!-- CSS only -->
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
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
    <a class="navbar-brand m-1" href="index.aspx">
        <img class="ms-4" src="/images/logo.png" alt="" width="110" height="60"> 
    </a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse"  id="navbarNav">
      <ul class="navbar-nav ms-4" >
        <li class="nav-item">
          <a class="nav-link" href="Clientes/Clientes.aspx">Clientes</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="Auto/Autos.aspx">Autos</a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="Mecanico/Mecanico.aspx">Mecanicos</a>
        </li>
      </ul>
    </div>
      <span class="navbar-text" style="font-weight:bold; font-style:italic; color=: white !important;">
  
           <p class="card-text text-white">Tu taller de confianza!</p>

      </span>

  </div>
    </nav>

   
        
            <form id="form1" class="container" runat="server">

                <div class="row mt-4" >
                    <div class="col-md-12">

                        <div class="card text-center">
                            <div class="card-header">
                            <h4>Iniciar una revisión</h4>
                            </div>
                            <div class="card-body">
                                <asp:Button CssClass="btn btn-primary" ID="btnClientes" runat="server" Text="Iniciar Revisión" OnClick="btnClientes_Click" />
                          </div>
                        </div>
                        
                     </div>
                </div>

                <div class="row mt-3">
                    <div class="col-md-12">
                         <div class="card text-center">
                            <div class="card-header">
                             <h4>Revisiones</h4>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="gridRevisiones" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1087px" OnSelectedIndexChanged="gridRevisiones_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:CommandField SelectText="Ver Revisión" ShowSelectButton="True" />
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
                            Dar en ver revisión para autorizar la reparación.
                          </div>
                        </div>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-md-12">
                         <div class="card text-center">
                            <div class="card-header">
                             <h4>Reparaciones</h4>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GridReparacion" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1087px" OnSelectedIndexChanged="GridReparacion_SelectedIndexChanged">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:CommandField SelectText="Garantia" ShowSelectButton="True" />
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
                            Mostrando las reparaciónes.
                          </div>
                        </div>
                    </div>
                </div>

             </form>

    
    <!-- JavaScript Bundle with Popper -->
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

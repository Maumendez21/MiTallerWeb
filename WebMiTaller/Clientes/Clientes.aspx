<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="WebMiTaller.Clientes.Clientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <title></title>
</head>
<body>

    <nav class="navbar navbar-dark bg-dark">
         <div class="container-fluid">
          <span class="navbar-brand" href="../index.aspx">Mi Taller</span>
          <span>Clientes</span>
         </div>
    </nav>


    <div class="row mt-4">
        <div class="col-md-12">
            <form id="form1" class="container" runat="server">
             <div>
                 <h1>Clientes</h1>
                 <asp:Button CssClass="btn btn-danger mb-3" ID="btnRegresar" runat="server" Text="Regresar" OnClick="btnRegresar_Click" />
                 <asp:Button CssClass="btn btn-primary mb-3" ID="btnAddClient" runat="server" Text="Agregar Cliente" OnClick="btnAddClient_Click" />

                 <asp:GridView ID="GridClientes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridClientes_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                     <Columns>
                         <asp:CommandField ShowSelectButton="True" AccessibleHeaderText="Ver Cliente" SelectText="Ver Cliente" />
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
            </form>
        </div>
    </div>
    

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Item_retete.aspx.cs" Inherits="Cabinet_medical.Item_retete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css"
        href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
</head>
<body style="padding-top: 10px">
    <div class="col-xs-8 col-xs-offset-2">
        <form id="form1" runat="server" class="form-horizontal">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3>Item_Retete </h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="inputId" class="control-label col-xs-2">
                            Id
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputId" placeholder="Id" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputIdReteta" class="control-label col-xs-2">
                            Id_Reteta
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputIdReteta" placeholder="Id_Reteta" />
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="inputIdMedicament" class="control-label col-xs-2">
                            Id_Medicament
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputIdMedicament" placeholder="Id_Medicament" />
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputDozaj" class="control-label col-xs-2">
                            Dozaj
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputDozaj" placeholder="Dozaj" />
                </div>
            </div>

             <div class="form-group">
                        <label for="inputCantitate" class="control-label col-xs-2">
                            Cantitate
                        </label>
                        <div class="col-xs-10">
                            <input type="text" runat="server" class="form-control"
                                id="inputCantitate" placeholder="Cantitate" />
                    </div>
                </div>

                <div class="form-group">
                    <div class="col-xs-10 xol-xs-offset-2">
                        <asp:Button ID="btnSearch" runat="server" Text="Search"
                            CssClass="btn btn-primary" OnClick="btnSearch_click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </div>
                </div>
            </div>
        </div>

        <div class="panel panel-primary">
            <div class="panel-heading">
                <h3>Search Results</h3>
            </div>
            <div class="panel-body">
                <div class="col-xs-10">
                    <asp:GridView CssClass="table table-bordered"
                        ID="gvSearchResults" runat="server">
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Cabinet_MedicalConnectionString %>" DeleteCommand="DELETE FROM [Item_reteta] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Item_reteta] ([Id], [Id_reteta], [Id_medicament], [Dozaj], [Cantitate]) VALUES (@Id, @Id_reteta, @Id_medicament, @Dozaj, @Cantitate)" SelectCommand="SELECT * FROM [Item_reteta]" UpdateCommand="UPDATE [Item_reteta] SET [Id_reteta] = @Id_reteta, [Id_medicament] = @Id_medicament, [Dozaj] = @Dozaj, [Cantitate] = @Cantitate WHERE [Id] = @Id">
                        <DeleteParameters>
                            <asp:Parameter Name="Id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="Id" Type="Int32" />
                            <asp:Parameter Name="Id_reteta" Type="Int32" />
                            <asp:Parameter Name="Id_medicament" Type="Int32" />
                            <asp:Parameter Name="Dozaj" Type="String" />
                            <asp:Parameter Name="Cantitate" Type="Double" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="Id_reteta" Type="Int32" />
                            <asp:Parameter Name="Id_medicament" Type="Int32" />
                            <asp:Parameter Name="Dozaj" Type="String" />
                            <asp:Parameter Name="Cantitate" Type="Double" />
                            <asp:Parameter Name="Id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </div>
            </div>
        </div>
    </form>
    </div>
</body>
</html>

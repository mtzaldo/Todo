<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Todo.aspx.cs" Inherits="Todo.WebForms.Todo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            <asp:Label runat="server" ID="lblHeader" />
        </h2>
        <asp:TextBox runat="server" ID="txtDescription" placeholder="description" AutoCompleteType="None" />
        <asp:Button runat="server" ID="btnCreate" Text="+" OnClick="btnCreate_Click" />
        <br />
        <br />
        <asp:GridView runat="server" ID="grvTodo" AutoGenerateColumns="false"  DataKeyNames="ID" ShowHeader="false" GridLines="None"
            OnPreRender="grvTodo_PreRender"
            OnRowDeleting="grvTodo_RowDeleting" 
            OnRowDataBound="grvTodo_RowDataBound"
            OnRowEditing="grvTodo_RowEditing"
            OnRowUpdating="grvTodo_RowUpdating">
            <Columns>
                <asp:CheckBoxField DataField="Completed" />
                <asp:BoundField DataField="Description" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="btnEdit" Text="e" CommandName="edit" />
                        <asp:Button runat="server" ID="btnSave" Text="s" CommandName="update" />
                        <asp:Button runat="server" ID="btnDelete" Text="d" CommandName="delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No items
            </EmptyDataTemplate>
        </asp:GridView>
        <h5>
            <asp:Label runat="server" ID="lblFooter" />
        </h5>
    </div>
    </form>
</body>
</html>
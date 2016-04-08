

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CS.aspx.cs" Inherits="CS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
<asp:textbox id="text1" Text="Имя сервера" runat="server"></asp:textbox>
<asp:textbox id="text2"  Text="Имя базы данных" runat="server"></asp:textbox>
        <br><br>
<asp:textbox id="text3"  Text="Логин" runat="server"></asp:textbox>
<asp:textbox id="text4"  Text="Пароль" runat="server"></asp:textbox>
         <br><br>
        <asp:textbox id="text5"  Text="Имя таблицы" runat="server"></asp:textbox>
    <asp:Button Text="Export" OnClick="ExportCSV" runat="server" />
    </form>
</body>
</html>

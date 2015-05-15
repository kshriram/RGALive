<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmSlipPrint.aspx.cs" Inherits="ShippingController_V1._0_.Forms.Web_Forms.frmSlipPrint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type ='text/css'>
P.pagebreakhere {page-break-before: always}
</style>
   <%-- <script type="text/javascript">
       
        $(function printpanel () {
         
                // Print the DIV.
                $("#printdiv").print();
                return (false);
            
        });
</script>--%>
</head>
     <%--<script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=prntdiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>--%>
    <%--onload="PrintPanel();--%>
<body onload="window.print();">
    
</body>
</html>

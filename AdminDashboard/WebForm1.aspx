<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AdminDashboard.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
</head>
      <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js">
</script>
    <script src="https://code.highcharts.com/highcharts.src.js"></script>
    <script language="javascript" type="text/javascript">    
        $(document).ready(function () {
            
            Getdata();

        });


             function Getdata() {
               
                $.ajax({
                    type: "POST",
                    url: "WebForm1.aspx/getdata",
                    datatype: "json",
                    contentType: "application/json; charset=utf-8",
                    data: {}
                })
                    .done(function (data) {             
                            ColumnChart(data.d.series);
                    });

        }

        function ColumnChart(Series) {
            console.log("!!!!!!!!!!!!!!!!!!!",Series),
            // Create the chart
            Highcharts.chart('container', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Bidding Status'
                },
                subtitle: {
                    text: ''
                },
                xAxis: {
                    type: 'category'
                },
                yAxis: {
                    title: {
                        text: 'Bid Amount ($)'
                    }

                },

                credits: {
                    enabled: false
                },
                legend: {
                    enabled: false
                },
                plotOptions: {
                    series: {
                        borderWidth: 0,
                        dataLabels: {
                            enabled: true,
                            format: '{point.y}'
                        }
                    }
                },

                tooltip: {
                    headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
                    pointFormat: '<span style="color:{point.color}">{point.name}</span>:<b>{point.y}</b><br/>'
                },

                "series": [
                    {
                        "name": "Current Highest Bid",
                        "data": Series
                    }
                ]

            });
            }
        

</script>
  


<body>
    <form id="form1" runat="server">
        <table width ="1200px"><tr><td width="100">
        <div>
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" ></asp:CheckBoxList>
            <asp:Button ID="Button1" Text="Disable Slots" OnClick="Button1_Click" runat="server"/>
        </div></td>
       <td width="1100"> <div id="container" margin-top: "1px;" style="width:900px; height:500px"></div></td>
            <td> <asp:DataGrid ID="Grid1" runat="server" PageSize="30" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">  
                    <Columns>  
                        <asp:BoundColumn HeaderText="SLOT" DataField="slot"></asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="BID AMOUNT" DataField="bid"></asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="FIRST NAME" DataField="first_name"></asp:BoundColumn>  
                        <asp:BoundColumn HeaderText="LAST NAME" DataField="last_name"></asp:BoundColumn>  
                        
                    </Columns>  
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />  
                    <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />  
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" Mode="NumericPages" />
                    <AlternatingItemStyle BackColor="White" />  
                    <ItemStyle BackColor="#FFFBD6" ForeColor="#333333" />  
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" /> </asp:DataGrid>  </td>
            </tr>
        </table>
    </form>
</body>
</html>

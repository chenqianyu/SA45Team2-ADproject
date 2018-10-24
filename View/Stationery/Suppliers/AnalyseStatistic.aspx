<%@ Page Title="" Language="C#" MasterPageFile="~/View/Stationery/MasterPageforManager.master" AutoEventWireup="true" CodeFile="AnalyseStatistic.aspx.cs" Inherits="Stationery_Suppliers_AnalyseStatistic" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

        <div class="table-inverse">
            <br />
            <h1>Generate Department/Supplier Statistic Charts</h1>
            <br />
            <br />

            <div class="row">
                <div class="col-3">
                    <label class="h5" for="DateFrom_textBox">Date From</label>
                    <%--<input type="text" class="datepicker" runat="server" id="datePickerFrom">--%>
                    <div class="form-group">

                        <asp:TextBox ID="datePickerFrom" CssClass="form-control" Text="" TextMode="Date" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-3">
                    <label class="h5" for="DateTo_textBox">Date To</label>
                    <div class="form-group">
                        <asp:TextBox ID="datepickerTo" CssClass="form-control" Text="" TextMode="Date" runat="server"></asp:TextBox>
                    </div>

                    <%--<input type="text" class="datepicker" runat="server" id="datePickerTo">--%>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="datePickerFrom" Text="Please Enter a valid From Date!" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <div class="col-3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="datePickerTo" Text="Please Enter a valid To Date!" ForeColor="red"></asp:RequiredFieldValidator>
                </div>
                <asp:CompareValidator ID="dateCompareValidator" runat="server" ControlToValidate="datePickerTo" ControlToCompare="datePickerFrom" Operator="GreaterThanEqual" Type="Date" ErrorMessage="The end date must be after the start date." ForeColor="red">
                </asp:CompareValidator>
            </div>
            <div class="row">
                <div class="col-3">
                    <asp:DropDownList ID="DropDownList1" runat="server"
                        CssClass="btn btn-light dropdown-item" BackColor="#666666" AutoPostBack="true" OnSelectedIndexChanged="show_item_description"
                        Style="-webkit-appearance: button" Width="200px">
                        <asp:ListItem Selected="true" disabled="disabled">Please Select An Item</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="col-3">
                    <asp:Label ID="Label1" CssClass="h5" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <br />
            <div class="row">
                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;       
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="SEARCH" Width="170px"
        CssClass="btn bg-teal" BorderStyle="None" Font-Bold="true" ForeColor="White" />
            </div>


        </div>

        <script>var timeError = "Sorry Time Is Wrong!";</script>

        <p runat="server" id="reportData">&nbsp;</p>
        <div id="googleChart_tb1"></div>
        <div>&nbsp;</div>
        <div id="googleChart_tb2"></div>


        <script>
            if (timeError == false) {
                google.charts.load('current', { 'packages': ['corechart'] });

                google.charts.setOnLoadCallback(drawChart);

                function drawChart() {

                    if (reportData_table1.length > 1) {
                        var options = {
                            'title': 'Analysis Report for Department-Quantity ' + period,
                            titleTextStyle: { color: 'white' },
                            'width': 1000,
                            'height': 500,
                            'backgroundColor': 'transparent',
                            'is3D': true,
                            legend: { position: 'right', maxLines: 3, color: 'white' },
                            hAxis: { textStyle: { color: 'white' }, baselineColor: 'white' },
                            vAxis: { textStyle: { color: 'white' }, baselineColor: 'white' },

                            tooltip: { isHtml: true },
                        };
                        var data1 = new google.visualization.arrayToDataTable(reportData_table1);
                        var chart1 = new google.visualization.ColumnChart(document.getElementById('googleChart_tb1'));
                        chart1.draw(data1, options);
                    }
                    else {
                        document.getElementById('googleChart_tb1').innerHTML = "<h3 style='color:red' align='center'>Sorry, Department-Quantity Record Is Not Found!</h3>";
                    }

                    if (reportData_table2.length > 1) {
                        var options = {
                            'title': 'Analysis Report for Department-TotalPrice ' + period,
                            titleTextStyle: { color: 'white' },
                            'width': 1000,
                            'height': 500,
                            'backgroundColor': 'transparent',
                            hAxis: { title: 'Total Price', color: 'white', textStyle: { color: 'white' }, textStyle: { color: 'white' }, baselineColor: 'white' },
                            vAxis: { color: 'white', textStyle: { color: 'white' }, baselineColor: 'white' },

                            tooltip: { isHtml: true },
                        };
                        var data2 = new google.visualization.arrayToDataTable(reportData_table2);
                        var chart2 = new google.visualization.ColumnChart(document.getElementById('googleChart_tb2'));
                        chart2.draw(data2, options);
                    }
                    else {
                        document.getElementById('googleChart_tb2').innerHTML = "<h3 style='color:red' align='center'>Sorry, Department-TotalPrice Record Is Not Found!</h3>";
                    }
                }
            }
            $(document).ready(function () {
                $("option[value='Please Select An Item']").attr('disabled', 'disabled');
                $('.row .col.s12 select').css('display', 'block');
            })
        </script>
    </form>
</asp:Content>

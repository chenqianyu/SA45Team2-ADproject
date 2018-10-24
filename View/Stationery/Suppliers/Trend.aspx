<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageforDepartmenthead.master" AutoEventWireup="true" CodeFile="Trend.aspx.cs" Inherits="View_Stationery_Suppliers_Prediction" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
        
    <h1 style="text-align: center;">View Department Requisition Trends</h1>
    <div class="row">
        <div class="col-3">
           <label class="h5" for="DateFrom_textBox">Date From</label>
            <%--<input type="text" class="datepicker" runat="server" id="datePickerFrom">--%>
           <div class="form-group">
           <asp:TextBox ID="datePickerFrom" CssClass="form-control" Text="" TextMode="Date" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="datePickerFrom" Text="Please Enter a valid From Date!" ForeColor="red"></asp:RequiredFieldValidator>
                 <i class="form-group__bar"></i>
                </div>
        </div>
        <div class="col-3">
            <label class="h5" for="DateTo_textBox">Date To</label>
            <div class="form-group">
              <asp:TextBox ID="datePickerTo" CssClass="form-control" Text="" TextMode="Date" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="datePickerTo" Text="Please Enter a valid To Date!" ForeColor="red"></asp:RequiredFieldValidator>
                <i class="form-group__bar"></i>
                </div>
            <asp:CompareValidator ID="dateCompareValidator" runat="server" ControlToValidate="datePickerTo" ControlToCompare="datePickerFrom" Operator="GreaterThanEqual" Type="Date" ErrorMessage="The end date must be after the start date." ForeColor="red">
        </asp:CompareValidator>
            <%--<input type="text" class="datepicker" runat="server" id="datePickerTo">--%>
        </div>
        <div class="col-12">
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"   CssClass="btn btn-light dropdown-item" BackColor="#666666"
                    Style="-webkit-appearance: button" Width="200px">
                <asp:ListItem Selected="true" disabled="disabled">Please Select An Item</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div style="text-align: center;">
            <br/>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        <div style="text-align: center;">
            <br/>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        <script>var averageError = "Sorry no average request quantity in this period"</script>
        </div>

        <div style="width:85%;float:left">
            <script>var timeError = "Sorry Time Is Wrong!";</script>
    <p runat="server" id="reportData">&nbsp;</p>
    <div id="googleChart_tb4"></div>

        <script>       
            if (timeError == false) {
                google.charts.load('current', { 'packages': ['corechart'] });

                google.charts.setOnLoadCallback(drawChart);

                function drawChart() {

                    if (reportData_table4.length > 1) {
                        console.log(timeError)
                        var options = {
                            'title': 'Analysis Report for Prediction ' + period,
                            titleTextStyle: { color: 'white' },
                            'width': 1000,
                            'height': 500,
                            'backgroundColor': 'transparent',
                            hAxis: { title: 'Time', textStyle: { color: 'white' }, baselineColor: 'white', direction: '-1' },
                            vAxis: { title: 'Request Quantity', minValue: 0, maxValue: 80, textStyle: { color: 'white' }, baselineColor: 'white' },
                            crosshair: { trigger: "both", orientation: "both" },
                            legend: 'none',
                            trendlines: {
                                0: {
                                    type: 'polynomial',
                                    degree: 3,
                                    visibleInLegend: true,
                                    color: 'purple',
                                    lineWidth: 10,
                                }
                            },    // Draw a trendline for data series 0.
                            tooltip: { isHtml: true },
                        };

                        var data4 = new google.visualization.arrayToDataTable(reportData_table4);
                        var chart4 = new google.visualization.LineChart(document.getElementById('googleChart_tb4'));
                        chart4.draw(data4, options);
                    }
                    else {
                        document.getElementById('googleChart_tb4').innerHTML = "<h3 style='color:red' align='center'>Sorry, Prediction Record Is Not Found!</h3>";
                    }
                }
            }

            $(document).ready(function () {
                $("option[value='Please Select An Item']").attr('disabled', 'disabled');
                $('.row .col.s12 select').css('display', 'block');

            })
    </script>
        </div>
    <div style="text-align: center; width:15%; float: right">
        <br/>
        <br/>
        <br/>
        <asp:RadioButtonList ID="RadioButton1" runat="server" ></asp:RadioButtonList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
            ControlToValidate="RadioButton1" ErrorMessage="Please select a department!" ForeColor="red" CssClass="h4"></asp:RequiredFieldValidator>
    </div>
    </div>
    <div style="text-align: center;">
        <asp:Button ID="Button2" runat="server" Text="View Trend" Width="170px" OnClick="Button2_Click" />
    </div>

</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Fixed-Account.aspx.cs" Inherits="Banking_WEB.Fixed_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable
                ();
        });
    </script>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="py-5">
        <div class="container-fluid" style="margin-top: 5rem;">
            <div class="row">


                <div class="col-md-4 mb-4 d-flex flex-column justify-content-between" style="gap: 1rem;">

                    <div class="card border-0 shadow-lg rounded-3 flex-fill w-100" style="min-height: 360px;">
                        <div class="card-body px-4 py-4 d-flex flex-column">
                            <h5 class="fw-bold mb-3 text-primary">
                                <i class="fas fa-cogs me-2"></i>Fixed Account Operations
                            </h5>

                            <!-- Account Summary -->
                            <ul class="list-group list-group-flush mb-3">
                                <li class="list-group-item">
                                    <i class="fas fa-wallet me-2 text-muted"></i>
                                    <strong>Current Balance:</strong>
                                    <span class="fw-semibold text-success">R <% = Session["Current_Amount_Fixed"] %>
                                    </span>
                                </li>
                                <li class="list-group-item">
                                    <i class="fas fa-exclamation-circle me-2 text-muted"></i>
                                    <strong>Account maintance Deduction:</strong> R100
                                </li>
                                <li class="list-group-item">
                                    <i class="fas fa-exclamation-circle me-2 text-muted"></i>
                                    <strong>Interest Rate Per Month:</strong> 15%
                                </li>
                                <li class="list-group-item">
                                    <i class="fas fa-exclamation-circle me-2 text-muted"></i>
                                    <strong>Contract Option:</strong> 5 Years
                                </li>
                                <li class="list-group-item">
                                    <i class="fas fa-exclamation-circle me-2 text-muted"></i>
                                    <strong>Early WithDrawals/Deposite To Another Account Deductions:</strong> R1,000
                                </li>
                            </ul>

                            <div class="mb-3">
                                <label class="form-label fw-semibold">
                                    <i class="fas fa-arrow-circle-up me-1 text-muted"></i>
                                    Deposite Funds
                                </label>
                                <div class="input-group">
                                    <asp:TextBox ID="txtDeposite" runat="server" CssClass="form-control" placeholder="Enter amount to deposite"></asp:TextBox>
                                    <asp:Button ID="btnDeposite" runat="server" Text="Deposite" CssClass="btn"
                                        Style="background-color: #28a745; color: white; border-color: #28a745;" OnClick="btnDeposite_Click" />
                                </div>
                            </div>
                        </div>

                    </div>



                    <div class="card border-0 shadow-lg rounded-3 flex-fill w-100" style="min-height: 300px;">
                        <div class="card-body px-4 py-4 d-flex flex-column">
                            <h5 class="fw-bold mb-3 text-primary">
                                <i class="fas fa-university me-2"></i>Transfer to a Foreign Account
                            </h5>

                            <div class="mb-3">
                                <label class="form-label">Recipient Account ID</label>
                                <asp:TextBox ID="txtRecipientID" runat="server" CssClass="form-control" placeholder="e.g., 203984"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label class="form-label">Amount</label>
                                <asp:TextBox ID="txtTransferAmount" runat="server" CssClass="form-control" placeholder="R0.00"></asp:TextBox>
                            </div>

                            <asp:Button ID="btnTransfer" runat="server" Text="Transfer" CssClass="btn mt-auto"
                                Style="background-color: #2b4d6e; color: white; border-color: #2b4d6e;" OnClick="btnTransfer_Click1" />
                        </div>
                    </div>
                </div>


                <div class="col-md-8 mb-4">
                    <div class="card shadow-lg border-0 w-100" style="min-height: 600px;">
                        <div class="card-body d-flex flex-column">
                            <h4 class="fw-bold text-primary mb-3 text-center">Recent Transactions</h4>
                            <div class="flex-grow-1 overflow-auto">
                                <asp:GridView ID="GridView1" runat="server"
                                    CssClass="table table-striped table-bordered"
                                    DataKeyNames="Transaction_Fixed_ID"
                                    EmptyDataText="No accounts found." DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Transaction_Fixed_ID" HeaderText="Transaction ID" InsertVisible="False" ReadOnly="True" SortExpression="Transaction_Fixed_ID" />
                                        <asp:BoundField DataField="Account_Number" HeaderText="Account Number" SortExpression="Account_Number" />
                                        <asp:BoundField DataField="Transaction_Date_Time" HeaderText="Date/Time" SortExpression="Transaction_Date_Time" />
                                        <asp:BoundField DataField="Transaction_Current_Amount" HeaderText="Current Amount" SortExpression="Transaction_Current_Amount" />
                                        <asp:BoundField DataField="Transaction_Transfer" HeaderText="Transfer" SortExpression="Transaction_Transfer" />
                                        <asp:BoundField DataField="Transaction_Deposite" HeaderText="Deposite" SortExpression="Transaction_Deposite" />
                                        <asp:BoundField DataField="Transaction_Foreign_Account_Number" HeaderText="Foreign Account Number" SortExpression="Transaction_Foreign_Account_Number" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Banking_AppConnectionString4 %>" SelectCommand="SELECT * FROM [Transaction_Fixed]"></asp:SqlDataSource>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>


    </main>




</asp:Content>

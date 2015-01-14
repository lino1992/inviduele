<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="Practicum.Account" %>

<!DOCTYPE html>

<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<link rel= "stylesheet" type="text/css" 
    href="StyleSheet1.css" />
    <title>Practicum</title>
    </head>
<body>
    <form id="form1" runat="server">
    <div class="balk">
        <div class="menubalk">
            <div class="Verlanglijst">
                <a href="Login.aspx"><button type="button" class="btn btn-default btn-lg active" id="Lb_login" runat="server">Login</button></a>
            </div>
            <div class="Bestelstatus">
                <a href="Verkooplijst.aspx"><button type="button" class="btn btn-default btn-lg active" id="Lb_Ver" runat="server" >Verkooplijst</button></a>
            </div>
            <div class="account">
                <a href="Account.aspx"><button type="button" class="btn btn-default btn-lg active">Account</button></a>
            </div>
        </div>
    </div>
        <div class="Home">
            <div class="Top">
             <div class="Logo">
            <a href ="index.aspx" ><img src="Bol-logo_big.jpg" /></a>           
        </div>
             <div class="Zoekbar">
             <asp:TextBox ID="TB_Zoek" runat="server" Width="462px"></asp:TextBox>
             <asp:Button ID="BT_Zoek" runat="server" Text="Zoek" Width="57px" />
             <button type="button" class="btn btn-default btn-lg active">
                 <a href="Bestellen.aspx"><img src="Shopping.png" Width="25px" /></a>
             </button>
         </div>
         <div class="Tekst">
             Gratis verzending vanaf 20 euro, gratis retourneren en 30 dagen bedenktijd
         </div>
                </div>
            <div class="Inhoud">
                <div class="A_A">
                    <div class="G_T">
                        <h5>Persoonlijke gegevens<asp:GridView ID="Gegevens_GD" runat="server" CssClass="Gegevens_GD" AutoGenerateColumns="False" DataKeyNames="KLANTID" DataSourceID="SqlDataSource1" Width="779px">
                            <Columns>
                                <asp:BoundField DataField="KLANTID" HeaderText="KLANTID" ReadOnly="True" SortExpression="KLANTID" />
                                <asp:BoundField DataField="NAAM" HeaderText="NAAM" SortExpression="NAAM" />
                                <asp:BoundField DataField="ACHTERNAAM" HeaderText="ACHTERNAAM" SortExpression="ACHTERNAAM" />
                                <asp:BoundField DataField="ADRES" HeaderText="ADRES" SortExpression="ADRES" />
                                <asp:BoundField DataField="POSTCODE" HeaderText="POSTCODE" SortExpression="POSTCODE" />
                                <asp:BoundField DataField="EMAIL" HeaderText="EMAIL" SortExpression="EMAIL" />
                            </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"></asp:SqlDataSource>
                        </h5>
                    </div>

                    
                </div>
                <div class="A_Ft">
                    <div class="G_T">
                        <h5>Facturen & betalingsinformatie</h5>
                    </div>
                    <div class="Facturen_g">
                        <asp:GridView ID="GD_Factuur" runat="server" AutoGenerateColumns="False" CssClass="Factuur_GD" DataKeyNames="FACTUURNUMMER" DataSourceID="SqlDataSourcefactuur" Width="778px">
                            <Columns>
                                <asp:BoundField DataField="FACTUURNUMMER" HeaderText="FACTUURNUMMER" ReadOnly="True" SortExpression="FACTUURNUMMER" />
                                <asp:BoundField DataField="ARTIKEL" HeaderText="ARTIKEL" SortExpression="ARTIKEL" />
                                <asp:BoundField DataField="TOTAALPRIJS" HeaderText="TOTAALPRIJS" SortExpression="TOTAALPRIJS" />
                                <asp:BoundField DataField="BETALINGMETHODE" HeaderText="BETALINGMETHODE" SortExpression="BETALINGMETHODE"/>
                                <asp:BoundField DataField="BETAALD" HeaderText="BETAALD" SortExpression="BETAALD" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourcefactuur" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" ></asp:SqlDataSource>
                       </div>
                </div>
                <div class="A_Vl">
                    <div class="G_T">
                        <h5>Verlanglijst</h5>
                    </div>
                    <div class="Facturen_g">

                        
                        <asp:GridView ID="GD_Verlanglijst" runat="server" AutoGenerateColumns="False" CssClass="Verlanglijst_GD" DataKeyNames="TITEL" DataSourceID="SqlDataSourceVerlanglijst" Width="779px">
                            <Columns>
                                <asp:BoundField DataField="TITEL" HeaderText="TITEL" ReadOnly="True" SortExpression="TITEL" />
                                <asp:BoundField DataField="ISBNNUMMER" HeaderText="ISBNNUMMER" SortExpression="ISBNNUMMER" />
                                <asp:BoundField DataField="EXPR1" HeaderText="BOEK" SortExpression="EXPR1"  />
                                </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSourceVerlanglijst" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" ></asp:SqlDataSource>
                       </div>
                </div>
                <div class="A_Vk">
                    <div class="G_T">
                        <h5>Gekochte boeken</h5>
                    </div>
                    <div class="Boeken_lijst">
                        <asp:GridView ID="Gekochte_boeken" runat="server" AutoGenerateColumns="False" CssClass="Gekochte_boeken" DataKeyNames="ISBNNUMMER" DataSourceID="SqlDataGekochteBoeken">
                            <Columns>
                                <asp:BoundField DataField="TITEL" HeaderText="TITEL" SortExpression="TITEL" />
                                <asp:BoundField DataField="ISBNNUMMER" HeaderText="ISBNNUMMER" ReadOnly="True" SortExpression="ISBNNUMMER" />
                                <asp:BoundField DataField="PRIJS" HeaderText="PRIJS" SortExpression="PRIJS"  />
                                <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS"  />
                                </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataGekochteBoeken" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" ></asp:SqlDataSource>
                       </div>
                </div>
            </div>
        </div>
        <div class="Footer">
            <h4>Made by Lino</h4>
        </div>
    </form>
</body>
</html>

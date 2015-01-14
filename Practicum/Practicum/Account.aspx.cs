using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Practicum.Classen;

namespace Practicum
{
    public partial class Account : System.Web.UI.Page
    {
        Int32 klantid = 0;
        Klant k = null;
        string status = "";
        private Uitvoering uitvoering = new Uitvoering();
        //bij deze page_load regel ik de interface van de account.aspx wat wil wordt aan getoont en wat niet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Klantid"] != null)
            {
                Lb_login.InnerText = "Log Out";
                klantid = (Int32)Session["Klantid"];
            }
            status = (string)Session["Status"];
            if (status == "KOPER")
            {
                Lb_Ver.Visible = false;
            }
            if (status == "VERKOPER")
            {
                Lb_Ver.Visible = true;
            }
            load();
        }
        /// <summary>
        /// bij deze methode laad ik de sqldatasource voor alle gridview die worden gebruikt in deze pagina
        /// </summary>
        private void load()
        {
            SqlDataSourcefactuur.SelectCommand = "SELECT f.FACTUURNUMMER, o.ARTIKEL, o.TOTAALPRIJS, b.BETALINGMETHODE, f.BETAALD FROM DB21_FACTUUR f, DB21_OVERZICHT o, DB21_BETALING b, DB21_BESTELLING be WHERE f.FACTUURNUMMER = o.FACTUURNUMMER AND f.FACTUURNUMMER = b.FACTUURNUMMER AND o.BESTELNUMMER = be.BESTELNUMMER AND (be.KLANTID = " + klantid +")";
            SqlDataSource1.SelectCommand = "SELECT KLANTID, NAAM, ACHTERNAAM, ADRES, POSTCODE, EMAIL FROM DB21_KLANT WHERE (KLANTID = " + klantid + ")";
            SqlDataSourceVerlanglijst.SelectCommand="SELECT v.TITEL, v.ISBNNUMMER, b.TITEL AS EXPR1 FROM DB21_VERLANGBOEK v, DB21_BOEK b WHERE v.ISBNNUMMER = b.ISBNNUMMER AND (v.KLANTID = "+ klantid + ")";
            SqlDataGekochteBoeken.SelectCommand = "SELECT bo.TITEL, bo.ISBNNUMMER, bo.PRIJS, bo.STATUS FROM DB21_BESTELLING b, DB21_BOEK bo WHERE b.ISBNNUMMER = bo.ISBNNUMMER AND (b.KLANTID = " + klantid + ")";
        }
        protected void FormView1_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {

        }
    }
}
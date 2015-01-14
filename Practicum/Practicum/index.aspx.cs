﻿using Practicum.Classen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Practicum
{
    public partial class index : System.Web.UI.Page
    {
        private Practicum.Classen.Uitvoering uitvoering;
        Int64 boekid = 0;
        string status = "";
        /// <summary>
        /// hier check ik of de session niet null zijn wanneer ze niet null zijn worden sommige functie uitgeschakeld
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Klantid"] != null)
            {
                Lb_login.InnerText = "Log Out";
                Lb_AC.Visible = true;
                Lb_Ver.Visible = true;
            }
            else
            {
                Lb_AC.Visible = false;
                Lb_Ver.Visible = false;
            }
            status = (string)Session["Status"];
            if(status == "KOPER")
            {
                Lb_Ver.Visible = false;
            }
            if(status == "VERKOPER")
            {
                Lb_Ver.Visible = true;
            }

        }
        /// <summary>
        /// deze methode worden gebruikt om de boeken te zoeken op naam of op isbnnummer
        /// </summary>
        private void gevonden()
        {
            Int64 number = Convert.ToInt64(TB_Zoek.Text);
            int result;
            bool check = false;
            if(int.TryParse(TB_Zoek.Text, out result))
            {
                check = true;
            }
            if(check == true)
            {
                SqlDataSourceGevonden.SelectCommand = "SELECT ISBNNUMMER, TITEL, PRIJS, STATUS FROM DB21_BOEK WHERE (TITEL ='" + TB_Zoek.Text + "')";
                
            }
            else
            {
                SqlDataSourceGevonden.SelectCommand = "SELECT ISBNNUMMER, TITEL, PRIJS, STATUS FROM DB21_BOEK WHERE (ISBNNUMMER =" + number + ")";
            }
            
        }
        /// <summary>
        /// deze click event laad de gevonden zoek resultaat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BT_Zoek_Click(object sender, EventArgs e)
        {
            gevonden();
        }
        /// <summary>
        /// wanneer een boek is gevonden en de gebruike selecteert dan ik sommige gegevens van de boek op en wordt de pagina bestellen geopend
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Gevonden_GD_SelectedIndexChanged(object sender, EventArgs e)
        {
            boekid = Convert.ToInt64(Gevonden_GD.SelectedRow.Cells[1].Text);
            if (Session["Klantid"] != null)
            {
                Session.Add("Boekid", boekid);
                Server.Transfer("Bestellen.aspx", true);
            }
            else
            {
                string script = "alert(\"Je moet eerst inloggen om een boek te kunnen bestellen\");";
                ScriptManager.RegisterStartupScript(this, GetType(),
                "ServerControlScript", script, true);
            }
        }
    }
}
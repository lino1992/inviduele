using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Oracle.DataAccess;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using Practicum.Classen;

namespace Practicum.Classen
{
    public class Uitvoering
    {
        /// <summary>
        /// hier wordt een select statement van plsql aangemaakt voor het controleren van inlog gegevens
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Klant Checklogin(string userid, string password)
        {
            OracleDataReader r = Database.readdata("select * from DB21_KLANT where userid='" + userid + "' and pasword ='" + password + "'");
            Klant k = null;
            while(r.Read())
            {
                int klantid = Convert.ToInt32(r["klantID"].ToString());
                string naam = r["naam"].ToString();
                string achternaam = r["achternaam"].ToString();
                string geboortedatum = r["geboortedatum"].ToString();
                string adres = r["adres"].ToString();
                string postcode = r["postcode"].ToString();
                string plaats = r["plaats"].ToString();
                string land = r["land"].ToString();
                string klant = r["klantstatus"].ToString();
                string user = r["userid"].ToString();
                string pasword = r["pasword"].ToString();
                string email = r["email"].ToString();
                k = new Klant(klantid, naam, achternaam, geboortedatum, adres, postcode, plaats, land, klant, user, pasword, email);
            }
            return k;
        }
        /// <summary>
        /// hier wordt een methode aangemaakt die wordt gebruikt om te checken of de mail al bestaat
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string Checkemail(string email)
        {
            string mail = "";
            OracleDataReader r = Database.readdata("select * from DB21_KLANT where email='" + email + "'");
            while(r.Read())
            {
                mail = r["email"].ToString();
            }
            return mail;
        }
        /// <summary> deze methoden wordt aangemaakt om de account te inserten in de database.
        public bool InsertAccount(string naam, string achternaam, string geboortedatum, string adres, string postcode, string plaats, string land, bool klantstatus, string pasword, string email)
        {
            string klants = "VERKOPER";
            if(klantstatus == true)
            {
                klants = "KOPER";
            }
            OracleCommand c = Database.storedprocedure("NewAccount");
            c.Parameters.Add("naam", OracleDbType.Varchar2).Value = naam;
            c.Parameters.Add("achternaam", OracleDbType.Varchar2).Value = achternaam;
            c.Parameters.Add("geboortedatum", OracleDbType.Varchar2).Value = geboortedatum;
            c.Parameters.Add("adres", OracleDbType.Varchar2).Value = adres;
            c.Parameters.Add("postcode", OracleDbType.Varchar2).Value = postcode;
            c.Parameters.Add("plaats", OracleDbType.Varchar2).Value = plaats;
            c.Parameters.Add("land", OracleDbType.Varchar2).Value = land;
            c.Parameters.Add("klantstatus", OracleDbType.Varchar2).Value = klants;
            c.Parameters.Add("pasword", OracleDbType.Varchar2).Value = pasword;
            c.Parameters.Add("email", OracleDbType.Varchar2).Value = email;
            c.ExecuteNonQuery();

            return true;
        }
        /// <summary>
        /// deze methoden wordt gebruikt om de gegeven van de ingelogde op te vragen
        /// </summary>
        /// <param name="klantid"></param>
        /// <returns></returns>
        public Klant GetInforUser(Int32 klantid)
        {
            Klant k = null;
            OracleDataReader r = Database.readdata("select * from DB21_KLANT where KLANTID =" + klantid);
            while(r.Read())
            {
                int id = Convert.ToInt32(r["klantID"].ToString());
                string naam = r["naam"].ToString();
                string achternaam = r["achternaam"].ToString();
                string geboortedatum = r["geboortedatum"].ToString();
                string adres = r["adres"].ToString();
                string postcode = r["postcode"].ToString();
                string plaats = r["plaats"].ToString();
                string land = r["land"].ToString();
                string klant = r["klantstatus"].ToString();
                string user = r["userid"].ToString();
                string pasword = r["pasword"].ToString();
                string email = r["email"].ToString();
                k = new Klant(klantid, naam, achternaam, geboortedatum, adres, postcode, plaats, land, klant, user, pasword, email);
            }
            return k;
        }
        /// <summary>
        /// deze methoden wordt gebruikt om gegevens van een boek terug te geven
        /// </summary>
        /// <param name="boekid"></param>
        /// <returns></returns>
        public Boek GetBoekinfor(Int64 boekid)
        {
            Boek b = null;
            OracleDataReader r = Database.readdata("select * from DB21_BOEK where ISBNNUMMER =" + boekid);
            while(r.Read())
            {
                Int64 id = Convert.ToInt64(r["isbnnummer"].ToString());
                string titel = r["titel"].ToString();
                decimal prijs = Convert.ToDecimal(r["prijs"].ToString());
                string status = r["status"].ToString();
                b = new Boek(id, titel, prijs, status);
            }
            return b;
        }
        /// <summary>
        /// deze methoden is aangemaakt voor het inserten van een nieuw bestellingen
        /// </summary>
        /// <param name="levering"></param>
        /// <param name="prijs"></param>
        /// <param name="klant"></param>
        /// <param name="isbnnummer"></param>
        /// <returns></returns>
        public bool NieuwBestelling(int levering, Int32 prijs, Int64 klant, Int64 isbnnummer)
        {
            OracleCommand c = Database.storedprocedure("Newbestelling");
            c.Parameters.Add("levering", OracleDbType.Int32).Value = levering;
            c.Parameters.Add("totaalprijs", OracleDbType.Int32).Value = prijs;
            c.Parameters.Add("klantid", OracleDbType.Int32).Value = klant;
            c.Parameters.Add("isbnnummer", OracleDbType.Int64).Value = isbnnummer;
            c.ExecuteNonQuery();
            return true;
        }
        /// <summary>
        /// deze methode wordt gebruikt voor het inserten van nieuw factuur
        /// </summary>
        /// <param name="prijs"></param>
        /// <param name="betaald"></param>
        /// <returns></returns>
        public bool NieuwFactuur(int prijs, int betaald)
        {
            OracleCommand c = Database.storedprocedure("NewFactuur");
            c.Parameters.Add("bedrag", OracleDbType.Int32).Value = prijs;
            c.Parameters.Add("betaal", OracleDbType.Int32).Value = betaald;
            c.ExecuteNonQuery();
            return true;
        }

    /// <summary>
        /// deze methode wordt gebruikt voor het inserten van nieuw betaling
    /// </summary>
    /// <param name="betaalmethode"></param>
    /// <param name="korting"></param>
    /// <returns></returns>
        public bool NieuwBetaling(string betaalmethode, Int32 korting)
        {
            OracleCommand c = Database.storedprocedure("NewBetaling");
            c.Parameters.Add("betalingmethode", OracleDbType.Varchar2).Value = betaalmethode;
            c.Parameters.Add("kortingcode", OracleDbType.Int32).Value = korting;
            c.ExecuteNonQuery();
            return true;
        }
        /// <summary>
        /// deze methode wordt gebruikt voor het inserten van nieuw boek
        /// </summary>
        /// <param name="titel"></param>
        /// <param name="prijs"></param>
        /// <param name="omschrijving"></param>
        /// <param name="isbnnummer"></param>
        /// <param name="klantid"></param>
        public void NieuwBoek(string titel, Int32 prijs, string omschrijving, Int64 isbnnummer, int klantid)
        {
            OracleCommand c = Database.storedprocedure("NewBoek");
            c.Parameters.Add("titel", OracleDbType.Varchar2).Value = titel;
            c.Parameters.Add("prijs", OracleDbType.Int32).Value = prijs;
            c.Parameters.Add("omschrijving", OracleDbType.Varchar2).Value = omschrijving;
            c.Parameters.Add("isbnnummer", OracleDbType.Int64).Value = isbnnummer;
            c.Parameters.Add("klantid", OracleDbType.Int64).Value = klantid;
            c.ExecuteNonQuery();
        }
    }
}
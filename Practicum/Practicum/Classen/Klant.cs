using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practicum.Classen
{
    public class Klant
    {
        private Int32 klantid;
        private string naam;
        private string achternaam;
        private string geboortedatum;
        private string adres;
        private string postcode;
        private string plaats;
        private string land;
        private string klantstatus;
        private string username;
        private string password;
        private string email;

        public Int32 Klantid { get { return klantid; } }
        public string Naam { get { return naam; } }
        public string Achternaam { get { return achternaam; } }
        public string Geboortedatum { get { return geboortedatum; } }
        public string Adres { get { return adres; } }
        public string Postcode { get { return postcode; } }
        public string Plaats { get { return plaats; } }
        public string Land { get { return land; } }
        public string Klantstatus { get { return klantstatus; } }
        public string Username { get { return username; } }
        public string Password { get { return password; } }
        public string Email{ get { return email; } }

        public Klant( Int32 klantid,string naam,string achternaam,string geboortedatum,string adres,string postcode,string plaats,string land,string klantstatus,string username,string password,string email)
        {
            this.klantid = klantid;
            this.naam = naam;
            this.achternaam = achternaam;
            this.geboortedatum = geboortedatum;
            this.adres = adres;
            this.postcode = postcode;
            this.plaats = plaats;
            this.postcode = postcode;
            this.klantstatus = klantstatus;
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }
}
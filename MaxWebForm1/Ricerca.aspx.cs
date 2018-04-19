using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class Ricerca : Page
	{
		public string id { get;set;}
		public string descrizione { get;set;}
		public string Messagge { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void Unnamed_Click(object sender,EventArgs e)
		{
			if(Page.IsValid) {
				id=Codice.Text;
				descrizione=Descrizione.Text;
				int codice;
				if (ID!="" && int.TryParse(id,out codice)) {
					var url=($"~/Dettaglio.aspx?id={codice}");
					Response.Redirect(url);
				}else if(descrizione!="") {
					var url=($"~/ListaProdotti.aspx?descrizione={descrizione}");
					Response.Redirect(url); 
				}
			}
		}
		protected void Controllo(object sender,ServerValidateEventArgs e)
		{
			if(Codice.Text != "" || Descrizione.Text != "") {
				e.IsValid=true;
			} else {
				e.IsValid=false;
			}
		}
	}
}
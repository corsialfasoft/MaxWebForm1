﻿using System;
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
		protected void Page_Load(object sender,EventArgs e)
		{

		}

		protected void Unnamed_Click(object sender,EventArgs e)
		{
			id=Codice.Text;
			descrizione=Descrizione.Text;
			int codice;
			if (ID!="" && int.TryParse(id,out codice)) {
				var url=String.Format($"~/Dettaglio.aspx?id={codice}");
				Response.Redirect(url);
			}else if(descrizione!="") {
				var url=String.Format($"~/ListaProdotti.aspx?descrizione={descrizione}");
				Response.Redirect(url);
			} else {
				
			}
		}
	}
}
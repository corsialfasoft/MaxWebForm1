using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class ListaProdotti : Page
	{
		public string parola { get;set;}
		Dao dao = new Dao();
		public List<Prodotto> Prodotti { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{
			Prodotti= dao.SearchProdotti(parola);

		}

		protected void Aggiungi(object sender,EventArgs e)
		{
		
		}
			protected void Indietro(object sender,EventArgs e)
		{
			var url="~/Ricerca.aspx?id=ID";
			Response.Redirect(url);
		}

		protected void Unnamed_Click(object sender,EventArgs e)
		{

		}
	}
	public partial class Dao
	{
		internal List<Prodotto> SearchProdotti(string parola)
		{
			List<Prodotto> trovati = new List<Prodotto>();
			Prodotto a = new Prodotto {Codice=133,Descrizione="staffa a X",Giacenza=1000};
			Prodotto b = new Prodotto {Codice=134,Descrizione="staffa a Y",Giacenza=1000};
			Prodotto c = new Prodotto {Codice=138,Descrizione="staffa a Z",Giacenza=1000};
			Prodotto d = new Prodotto {Codice=135,Descrizione="staffa a K",Giacenza=1000};
			Prodotto e = new Prodotto {Codice=139,Descrizione="staffa a J",Giacenza=1000};
			trovati.Add(a);
			trovati.Add(b);
			trovati.Add(c);
			trovati.Add(d);
			trovati.Add(e);
			return trovati;
		}
	}
}
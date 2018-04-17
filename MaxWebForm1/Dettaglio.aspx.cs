using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class Dettaglio : Page
	{
		public int id;
		public int quantità;
		Dao dao = new Dao();
		public Prodotto prodotto { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{
			prodotto= dao.Search(id);
			codice.Text = prodotto.Codice.ToString();
			descrizione.Text=prodotto.Descrizione;
			Giacenza.Text=prodotto.Giacenza.ToString();

		}

		protected void Aggiungi(object sender,EventArgs e)
		{
			dao.Add(prodotto,quantità);
			var url="~/Ricerca.aspx?message=ok";
			Response.Redirect(url);

		}
			protected void Indietro(object sender,EventArgs e)
		{
			var url="~/Ricerca.aspx?id=ID";
			Response.Redirect(url);
		}
	}
	public class Prodotto
	{
		public int Codice { get;set;}
		public string Descrizione { get;set;}
		public int Giacenza { get;set;}
	}
	public partial class Dao
	{
		public Prodotto Search(int id)
		{
			return new Prodotto{Codice=122,Descrizione="Staffa a X", Giacenza= 1000};
		}
		public void Add(Prodotto prodotto,int quantita)
		{
			//banane
		}
	}
}
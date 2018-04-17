using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class Dettaglio : Page
	{
		public int id { get;set;}
		public int quantità;
		Dao dao = new Dao();
		public Prodotto prodotto { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{
			int a = int.Parse(Request["id"]);
			id = a;
			prodotto= dao.Search(id);
			codice.Text = prodotto.Codice.ToString();
			descrizione.Text=prodotto.Descrizione;
			Giacenza.Text=prodotto.Giacenza.ToString();

		}

		protected void Aggiungi(object sender,EventArgs e)
		{
			int q;
			List<Prodotto> carrello = Session["carrello"] as List<Prodotto>;
			if(carrello == null) {
				carrello = new List<Prodotto>();
			}
			int.TryParse(Quantita.Text,out q);
				prodotto.Quantita= q;
				carrello.Add(prodotto);
				Session["carrello"] = prodotto;
			var url="~/Ricerca.aspx?message=ok";
			Response.Redirect(url);

		}
			protected void Indietro(object sender,EventArgs e)
		{
			var url="~/Ricerca.aspx?";
			Response.Redirect(url);
		}
	}
	public class Prodotto
	{
		public int Codice { get;set;}
		public string Descrizione { get;set;}
		public int Giacenza { get;set;}
		public int Quantita { get;set;}
	}
	public partial class Dao
	{
		private string GetConnection()
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource=@"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog="RICHIESTE";
			return  builder.ToString();
		}
		public Prodotto Search(int id)
		{
			Prodotto trovato = new Prodotto();
			SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.SearchByID",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value=id;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
				   trovato = new Prodotto {Codice=reader.GetInt32(0),Descrizione=reader.GetString(1),Giacenza=reader.GetInt32(2)};
				}
				reader.Close();
				command.Dispose();
				return trovato;
				}catch (Exception e) {
				throw e; 
				} finally { 
				connection.Dispose();
				}
		}
		public void Add(Prodotto prodotto,int quantita)
		{
			//banane
		}
	}
}
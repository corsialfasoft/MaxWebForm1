using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class ListaProdotti : Page
	{
		public string Messaggio { get;set;}
		public string parola { get;set;}
		Dao dao = new Dao();
		public List<Prodotto> Prodotti { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{
			string a = Request["descrizione"];
			parola = a;
			Prodotti= dao.SearchProdotti(parola);
			if(Prodotti.Count > 0) {
				for (int j=0 ; j < Prodotti.Count; j++) {
					Prodotto product = Prodotti[j];
					TableRow tableRow=new TableRow();
					TableCell tc = new TableCell();
					Label l1= new Label();
					l1.Text= product.Codice.ToString();
					tc.Controls.Add(l1);
					tableRow.Cells.Add(tc);

					TableCell tc2=new TableCell();
					Label l2 = new Label();
					l2.Text = product.Descrizione;
					tc2.Controls.Add(l2);
					tableRow.Cells.Add(tc2);

					//TableCell tc3 = new TableCell();
					//Label l3 = new Label();
					//l3.Text = product.Giacenza.ToString();
					//tc3.Controls.Add(l3);
					//tableRow.Cells.Add(tc3);

					TableCell tc4 = new TableCell();
					Button bottone = new Button();
					bottone.PostBackUrl=$"~/Dettaglio.aspx?id={product.Codice}";
					bottone.Text="Dettaglio Prodotto";
					tc4.Controls.Add(bottone);
					tableRow.Cells.Add(tc4);

					Table22.Rows.Add(tableRow);
				}
			} else {
				Messaggio="Non è stato trovato nessun elemento";
			}
		}
	}
	public partial class Dao
	{
		internal List<Prodotto> SearchProdotti(string parola)
		{
			List<Prodotto> trovati = new List<Prodotto>();
			SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.SearchString",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@parola",System.Data.SqlDbType.NVarChar).Value=parola;
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
				   trovati.Add(new Prodotto {Codice=reader.GetInt32(0),Descrizione=reader.GetString(1),Giacenza=reader.GetInt32(2)});
				}
				reader.Close();
				command.Dispose();
				return trovati;
				}catch (Exception e) {
				throw e; 
				} finally { 
				connection.Dispose();
				}
		}
	}
}
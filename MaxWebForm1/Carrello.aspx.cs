using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class Carrello : Page
	{
		public List<Prodotto> prodottos;
		public string Message { get;set;}
		Dao dao = new Dao();
		protected void Page_Load(object sender,EventArgs e)
		{
			prodottos = Session["carrello"] as List<Prodotto>;
			if(prodottos == null) {
				prodottos=new List<Prodotto>();
			}
			if (prodottos.Count>0) {
				for (int j = 0 ; j< prodottos.Count ; j++) {
					TableRow tableRow = new TableRow();
					TableCell cell = new TableCell();
					Label codice = new Label();
					codice.Text=prodottos[j].Codice.ToString();
					cell.Controls.Add(codice);
					tableRow.Cells.Add(cell);

					
					TableCell cell1 = new TableCell();
					Label descrizione = new Label();
					descrizione.Text=prodottos[j].Descrizione;
					cell1.Controls.Add(descrizione);
					tableRow.Cells.Add(cell1);

					TableCell cell2 = new TableCell();
					Label quantita = new Label();
					quantita.Text=prodottos[j].Quantita.ToString();
					cell2.Controls.Add(quantita);
					tableRow.Cells.Add(cell2);

					Table24.Rows.Add(tableRow);
				}
			} else {
				Message="Il carrello è vuoto!";
			}
		}

		protected void Svuota_Click(object sender,EventArgs e)
		{
			Session["carrello"]=new List<Prodotto>();
			prodottos=new List<Prodotto>();
			Message="Il carrello è vuoto!";
		}

		protected void Compra_Click(object sender,EventArgs e)
		{
			int richiesta = dao.CreaRichiesta();
			prodottos = Session["carrello"] as List<Prodotto>;
			foreach (Prodotto element in prodottos) {
				dao.Compra(richiesta,element);
			}
			Session["carrello"]=new List<Prodotto>();
			prodottos=new List<Prodotto>();
			
				var url=String.Format($"~/Ricerca.aspx");
				Response.Redirect(url);
		}
	}
	public partial class Dao
	{
		internal void Compra(int richiesta,Prodotto prodotto)
		{
			SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CreaOrdini",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@idRichiesta",System.Data.SqlDbType.Int).Value=richiesta;
				command.Parameters.Add("@idProdotti",System.Data.SqlDbType.Int).Value=prodotto.Codice;
				command.Parameters.Add("@quantita",System.Data.SqlDbType.Int).Value=prodotto.Quantita;
				command.ExecuteNonQuery();
				command.Dispose();
				}catch(Exception x) {
				throw x;
				} finally {
				connection.Close();
				}
		}

		internal int CreaRichiesta()
		{
			int richiesta=0;
			SqlConnection connection = new SqlConnection(GetConnection());
			try {
				connection.Open();
				SqlCommand command = new SqlCommand("dbo.CreaRichiesta",connection);
				command.CommandType=System.Data.CommandType.StoredProcedure;
				command.Parameters.Add("@date",System.Data.SqlDbType.Date).Value=DateTime.Now.ToString("dd-MM-yyyy");
				SqlDataReader reader = command.ExecuteReader();
				while(reader.Read()) {
					richiesta = (int)reader.GetDecimal(0);
				}
				reader.Close();
				command.Dispose();
				return richiesta;
				}catch(Exception x) {
				throw x;
				} finally {
				connection.Close();
				}
		}
	}
}
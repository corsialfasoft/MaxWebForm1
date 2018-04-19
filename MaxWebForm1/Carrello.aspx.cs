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
				CarrelloPage.Product=prodottos;
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

		public void Cancella_Click(object sender,CommandEventArgs e)
		{
			prodottos = (List<Prodotto>)Session["carrello"];
			int x ;
			int.TryParse((string)e.CommandArgument,out x);
			for (int i=0 ;i<prodottos.Count; i++) {
				if (prodottos[i].Codice == x) {
					prodottos.Remove(prodottos[i]);
				}
			}
			Session["carrello"] = prodottos;
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
			
				var url=($"~/Ricerca.aspx");
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
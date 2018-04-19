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
			Lista.Product=Prodotti;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class ProductList : System.Web.UI.UserControl
	{
		public bool IsEliminaEnabled { get;set;}
		public bool IsDetailEnabled { get;set;}
		public bool IsQuantitaEnabled{ get;set;}
		public bool IsGiacenzaEnabled { get;set;}
		public List<Prodotto> Product { get;set;}
		protected void Page_Load(object sender,EventArgs e)
		{
			if(Product == null) {
				Product=new List<Prodotto>();
			}
			foreach (Prodotto prodotto in Product) {
				TableRow tableRow = new TableRow();
				tableRow.Cells.Add(AddCella(new Label{Text=prodotto.Codice.ToString(),CssClass="col-md-3"}));
				tableRow.Cells.Add(AddCella(new Label{Text=prodotto.Descrizione,CssClass="col-md-3"}));
				if(IsGiacenzaEnabled) {
					tableRow.Cells.Add(AddCella(new Label{Text=prodotto.Giacenza.ToString(),CssClass="col-md-3"}));
				}
				if(IsQuantitaEnabled) { 
					tableRow.Cells.Add(AddCella(new Label{Text=prodotto.Quantita.ToString()}));
				}
				if(IsEliminaEnabled) {
					tableRow.Cells.Add(AddBotton(prodotto));
				}
				if(IsDetailEnabled) {
					tableRow.Cells.Add(AddCella(new Button { Text="Dettaglio", PostBackUrl=$"/Dettaglio.aspx?id={prodotto.Codice}"}));
				}
				ProductTable.Rows.Add(tableRow);
			}

		}
		protected TableCell AddBotton(Prodotto prodotto)
		{
			Carrello carrello = new Carrello();
			TableCell cella = new TableCell();
			Button button = new Button();
			button.Command+= carrello.Cancella_Click;
			button.CommandArgument=prodotto.Codice.ToString();
			button.Text= "Elimina";
			cella.Controls.Add(button);
			return cella;
		}


		protected void Carica (object sender,EventArgs e)
		{
		}
		protected TableCell AddCella(Control controllo)
		{
			TableCell cella = new TableCell();
			cella.Controls.Add(controllo);
			return cella;
		}
	}
}
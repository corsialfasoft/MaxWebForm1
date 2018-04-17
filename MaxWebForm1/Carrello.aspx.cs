using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MaxWebForm1
{
	public partial class Carrello : Page
	{
		List<Prodotto> prodottos;
		protected void Page_Load(object sender,EventArgs e)
		{
			prodottos = Session["carrello"] as List<Prodotto>;
			if (prodottos!= null) {
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
			}
		}
	}
	public partial class Dao
	{
	}
}
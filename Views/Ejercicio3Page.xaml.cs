namespace ActividadMauiApp.Views;

public partial class Ejercicio3Page : ContentPage
{
	public Ejercicio3Page()
	{
		InitializeComponent();
		CalcularTotal();
	}

	private void OnOpcionCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		CalcularTotal();
	}

	private void OnMontoBaseTextChanged(object sender, TextChangedEventArgs e)
	{
		CalcularTotal();
	}

	/// <summary>
	/// Evalúa las casillas activas y calcula el total de acuerdo al monto base y opciones.
	/// </summary>
	private void CalcularTotal()
	{
		if (lblTotal == null || lblDetalle == null) return;

		// Obtener subtotal base
		double.TryParse(txtMontoBase?.Text, out double baseMonto);
		if (baseMonto < 0) baseMonto = 0;

		double adicional = 0;
		double descuento = 0;
		var opciones = new List<string>();

		if (chkGarantia != null && chkGarantia.IsChecked)
		{
			adicional += 25.00;
			opciones.Add("Garantía Extendida (+$25)");
		}

		if (chkEnvioExpress != null && chkEnvioExpress.IsChecked)
		{
			adicional += 15.00;
			opciones.Add("Envío Express (+$15)");
		}

		if (chkDescuento != null && chkDescuento.IsChecked)
		{
			descuento = baseMonto * 0.10;
			opciones.Add($"Descuento 10% (-${descuento:N2})");
		}

		double totalFinal = (baseMonto - descuento) + adicional;
		if (totalFinal < 0) totalFinal = 0;

		lblTotal.Text = $"${totalFinal:N2}";

		if (opciones.Count > 0)
		{
			lblDetalle.Text = string.Join("\n• ", opciones);
			lblDetalle.Text = "• " + lblDetalle.Text;
		}
		else
		{
			lblDetalle.Text = "Ningún adicional seleccionado.";
		}
	}

	private void OnRestablecerClicked(object sender, EventArgs e)
	{
		txtMontoBase.Text = "100";
		chkGarantia.IsChecked = false;
		chkEnvioExpress.IsChecked = false;
		chkDescuento.IsChecked = false;
		CalcularTotal();
	}
}

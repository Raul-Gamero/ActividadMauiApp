namespace ActividadMauiApp.Views;

public partial class Ejercicio2Page : ContentPage
{
	public Ejercicio2Page()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Evento que detecta cuando el usuario cambia de RadioButton seleccionado.
	/// </summary>
	private void OnOperacionCheckedChanged(object sender, CheckedChangedEventArgs e)
	{
		if (sender is RadioButton rb && rb.IsChecked)
		{
			lblOperacionSeleccionada.Text = $"Operación: {rb.Content}";
		}
	}

	/// <summary>
	/// Ejecuta la operación matemática correspondiente al RadioButton activo.
	/// </summary>
	private async void OnCalcularClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrWhiteSpace(txtNum1.Text) || string.IsNullOrWhiteSpace(txtNum2.Text))
		{
			await DisplayAlert("Atención", "Por favor ingresa ambos números.", "Aceptar");
			return;
		}

		if (!double.TryParse(txtNum1.Text, out double n1))
		{
			await DisplayAlert("Error", "El primer valor no es un número válido.", "Aceptar");
			return;
		}

		if (!double.TryParse(txtNum2.Text, out double n2))
		{
			await DisplayAlert("Error", "El segundo valor no es un número válido.", "Aceptar");
			return;
		}

		double resultado = 0;

		if (rbSuma.IsChecked)
		{
			resultado = n1 + n2;
		}
		else if (rbResta.IsChecked)
		{
			resultado = n1 - n2;
		}
		else if (rbMultiplicacion.IsChecked)
		{
			resultado = n1 * n2;
		}
		else if (rbDivision.IsChecked)
		{
			// Control para evitar indeterminación por división entre cero
			if (n2 == 0)
			{
				await DisplayAlert("Error Matemático", "No es posible dividir entre cero.", "Aceptar");
				lblResultado.Text = "Error: Div / 0";
				return;
			}
			resultado = n1 / n2;
		}

		lblResultado.Text = $"{resultado:N2}";
	}

	private void OnLimpiarClicked(object sender, EventArgs e)
	{
		txtNum1.Text = string.Empty;
		txtNum2.Text = string.Empty;
		rbSuma.IsChecked = true;
		lblResultado.Text = "--";
		txtNum1.Focus();
	}
}

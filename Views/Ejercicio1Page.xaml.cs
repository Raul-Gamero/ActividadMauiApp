namespace ActividadMauiApp.Views;

public partial class Ejercicio1Page : ContentPage
{
	public Ejercicio1Page()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Evento Clicked del botón Sumar.
	/// Aplica variables, tipos de datos (double), operadores aritméticos y manejo de excepciones.
	/// </summary>
	private async void OnSumarClicked(object sender, EventArgs e)
	{
		// Validación de campos vacíos
		if (string.IsNullOrWhiteSpace(txtNumero1.Text) || string.IsNullOrWhiteSpace(txtNumero2.Text))
		{
			await DisplayAlert("Atención", "Por favor ingresa ambos números para continuar.", "Aceptar");
			return;
		}

		// Conversión de tipos de datos con TryParse para evitar bloqueos
		if (!double.TryParse(txtNumero1.Text, out double numero1))
		{
			await DisplayAlert("Error", "El primer valor ingresado no es un número válido.", "Aceptar");
			return;
		}

		if (!double.TryParse(txtNumero2.Text, out double numero2))
		{
			await DisplayAlert("Error", "El segundo valor ingresado no es un número válido.", "Aceptar");
			return;
		}

		// Operador aritmético de suma
		double resultado = numero1 + numero2;

		// Asignación y visualización del resultado
		lblResultado.Text = $"{resultado:N2}";
	}

	/// <summary>
	/// Limpia los campos de texto y restablece la etiqueta de resultado.
	/// </summary>
	private void OnLimpiarClicked(object sender, EventArgs e)
	{
		txtNumero1.Text = string.Empty;
		txtNumero2.Text = string.Empty;
		lblResultado.Text = "--";
		txtNumero1.Focus();
	}
}

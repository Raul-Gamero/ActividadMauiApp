namespace ActividadMauiApp.Views;

public partial class Ejercicio4Page : ContentPage
{
	public Ejercicio4Page()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Evento que se dispara cuando el usuario cambia el elemento seleccionado en el Picker.
	/// </summary>
	private void OnPickerOperacionChanged(object sender, EventArgs e)
	{
		if (pickerOperacion.SelectedIndex != -1)
		{
			string operacion = (string)pickerOperacion.SelectedItem;
			lblOperacionInfo.Text = $"Operación elegida: {operacion}";
		}
	}

	/// <summary>
	/// Realiza la operación aritmética elegida en el Picker entre los dos operandos.
	/// </summary>
	private async void OnCalcularOperacionClicked(object sender, EventArgs e)
	{
		// Validar que se haya seleccionado una opción en el Picker
		if (pickerOperacion.SelectedIndex == -1)
		{
			await DisplayAlert("Atención", "Por favor selecciona una operación del desplegable (Picker).", "Aceptar");
			return;
		}

		// Validar campos vacíos
		if (string.IsNullOrWhiteSpace(txtOperando1.Text) || string.IsNullOrWhiteSpace(txtOperando2.Text))
		{
			await DisplayAlert("Atención", "Por favor ingresa ambos operandos.", "Aceptar");
			return;
		}

		// Validar conversión numérica
		if (!double.TryParse(txtOperando1.Text, out double op1))
		{
			await DisplayAlert("Error", "El primer operando no es un número válido.", "Aceptar");
			return;
		}

		if (!double.TryParse(txtOperando2.Text, out double op2))
		{
			await DisplayAlert("Error", "El segundo operando no es un número válido.", "Aceptar");
			return;
		}

		double resultado = 0;
		string operacion = (string)pickerOperacion.SelectedItem;

		switch (pickerOperacion.SelectedIndex)
		{
			case 0: // Suma (+)
				resultado = op1 + op2;
				break;
			case 1: // Resta (-)
				resultado = op1 - op2;
				break;
			case 2: // Multiplicación (*)
				resultado = op1 * op2;
				break;
			case 3: // División (/)
				if (op2 == 0)
				{
					await DisplayAlert("Error Matemático", "No es posible dividir entre cero.", "Aceptar");
					lblResultado.Text = "Error: Div / 0";
					return;
				}
				resultado = op1 / op2;
				break;
			default:
				await DisplayAlert("Error", "Operación no reconocida.", "Aceptar");
				return;
		}

		lblResultado.Text = $"{resultado:N2}";
		lblOperacionInfo.Text = $"Cálculo: {op1} {operacion} {op2} = {resultado:N2}";
	}

	private void OnLimpiarClicked(object sender, EventArgs e)
	{
		txtOperando1.Text = string.Empty;
		txtOperando2.Text = string.Empty;
		pickerOperacion.SelectedIndex = -1;
		lblOperacionInfo.Text = "Operación: No seleccionada";
		lblResultado.Text = "--";
		txtOperando1.Focus();
	}
}

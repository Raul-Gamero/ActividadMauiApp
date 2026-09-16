using System.Collections.ObjectModel;

namespace ActividadMauiApp.Views;

public partial class Ejercicio5Page : ContentPage
{
	// Colección dinámica observable que notifica a la interfaz gráfica ante cambios
	private readonly ObservableCollection<string> _coleccionFrutas;

	// Variable para almacenar temporalmente el elemento seleccionado en el ListView
	private string? _frutaSeleccionada;

	public Ejercicio5Page()
	{
		InitializeComponent();

		// Inicialización de la colección con elementos de prueba iniciales
		_coleccionFrutas = new ObservableCollection<string>
		{
			"Manzana",
			"Plátano",
			"Fresa",
			"Naranja"
		};

		// Enlace de datos de la colección al control ListView
		lstFrutas.ItemsSource = _coleccionFrutas;

		ActualizarContador();
	}

	/// <summary>
	/// Añade un nuevo elemento a la colección de datos.
	/// </summary>
	private async void OnAgregarFrutaClicked(object sender, EventArgs e)
	{
		string nombreFruta = txtFruta.Text?.Trim() ?? string.Empty;

		if (string.IsNullOrWhiteSpace(nombreFruta))
		{
			await DisplayAlert("Atención", "Por favor escribe el nombre de una fruta.", "Aceptar");
			return;
		}

		// Evitar duplicados exactos (opcional para mantener integridad)
		if (_coleccionFrutas.Any(f => f.Equals(nombreFruta, StringComparison.OrdinalIgnoreCase)))
		{
			await DisplayAlert("Duplicado", $"La fruta '{nombreFruta}' ya existe en la lista.", "Aceptar");
			return;
		}

		// Método Add() de la colección
		_coleccionFrutas.Add(nombreFruta);

		txtFruta.Text = string.Empty;
		txtFruta.Focus();

		ActualizarContador();
	}

	/// <summary>
	/// Detecta el elemento seleccionado en el ListView.
	/// </summary>
	private void OnFrutaItemSelected(object sender, SelectedItemChangedEventArgs e)
	{
		if (e.SelectedItem != null)
		{
			_frutaSeleccionada = e.SelectedItem as string;
		}
	}

	/// <summary>
	/// Elimina el elemento seleccionado de la colección de datos mediante Remove().
	/// </summary>
	private async void OnEliminarSeleccionadaClicked(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(_frutaSeleccionada))
		{
			await DisplayAlert("Atención", "Por favor selecciona primero una fruta de la lista tocándola.", "Aceptar");
			return;
		}

		bool confirmar = await DisplayAlert("Confirmación", $"¿Deseas eliminar '{_frutaSeleccionada}' de la colección?", "Sí, eliminar", "Cancelar");
		if (confirmar)
		{
			// Método Remove() de la colección
			_coleccionFrutas.Remove(_frutaSeleccionada);
			_frutaSeleccionada = null;
			lstFrutas.SelectedItem = null;
			ActualizarContador();
		}
	}

	/// <summary>
	/// Vacía completamente la colección mediante Clear().
	/// </summary>
	private async void OnVaciarListaClicked(object sender, EventArgs e)
	{
		if (_coleccionFrutas.Count == 0)
		{
			await DisplayAlert("Lista Vacía", "No hay frutas en la colección para eliminar.", "Aceptar");
			return;
		}

		bool confirmar = await DisplayAlert("Vaciar Lista", "¿Estás seguro de que deseas eliminar todas las frutas?", "Sí, vaciar", "Cancelar");
		if (confirmar)
		{
			// Método Clear() de la colección
			_coleccionFrutas.Clear();
			_frutaSeleccionada = null;
			lstFrutas.SelectedItem = null;
			ActualizarContador();
		}
	}

	private void ActualizarContador()
	{
		lblContador.Text = $"Total: {_coleccionFrutas.Count} frutas";
	}
}

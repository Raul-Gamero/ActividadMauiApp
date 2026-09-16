namespace ActividadMauiApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnIrAEjercicio1Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Ejercicio1Page");
	}

	private async void OnIrAEjercicio2Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Ejercicio2Page");
	}

	private async void OnIrAEjercicio3Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Ejercicio3Page");
	}

	private async void OnIrAEjercicio4Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Ejercicio4Page");
	}

	private async void OnIrAEjercicio5Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//Ejercicio5Page");
	}
}

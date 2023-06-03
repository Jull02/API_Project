using ContactoAPI.Models;
using ContactoAPI.Services;
using System.Collections.ObjectModel;

namespace ContactoAPI;

public partial class ContactosPage : ContentPage
{
	private readonly IContactoRepository dataService;
	public ContactosPage()
	{
		InitializeComponent();

		dataService = new ContactoService();

		Console.WriteLine("**********************MainPage");
	}

	public async void onItemSelectedDetails(object sender, SelectedItemChangedEventArgs e)
	{
		Contacto contacto = (Contacto)e.SelectedItem;
		await Navigation.PushAsync(new DetailsPage()
		{
			BindingContext = contacto
		});

	}

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		ListaContactos.ItemsSource = new ObservableCollection<Contacto>(await dataService.GetContactosAsync());

	}

	public async void onClickNuevoContacto(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new NuevoContactoPage());
	}

}
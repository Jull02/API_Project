using ContactoAPI.Models;
using ContactoAPI.Services;

namespace ContactoAPI;

public partial class DetailsPage : ContentPage
{
	private readonly IContactoRepository _dataService;
	public DetailsPage()
	{
		InitializeComponent();
		_dataService = new ContactoService();
		Contacto contactoOb = BindingContext as Contacto;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		Contacto contactoOb = BindingContext as Contacto;

		imagenContacto.Source = contactoOb.Imagen;
		nombreContacto.Text = contactoOb.Nombre;
		apellidoContacto.Text = contactoOb.Apellido;
		cedulaContacto.Text = contactoOb.Cedula;
		direccionContacto.Text = contactoOb.Direccion;
		telefonoContacto.Text = contactoOb.Telefono;
		emailContacto.Text = contactoOb.Email;
	}

	public async void onClickEliminarContacto(object sender, EventArgs e)
	{
		Contacto contactoEl = BindingContext as Contacto;
		await _dataService.DeleteContactoAsync(contactoEl.ContactoId);
		await Navigation.PopAsync();
	}

	public async void onClickEditarContacto(object sender, EventArgs e)
	{
		//Contacto contactoEd = BindingContext as Contacto;
		await Navigation.PushAsync(new NuevoContactoPage()
		{
			BindingContext = BindingContext as Contacto
		});
	}
}
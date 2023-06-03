using ContactoAPI.Models;
using ContactoAPI.Services;

namespace ContactoAPI;

public partial class NuevoContactoPage : ContentPage 
{
	Contacto contacto;
	private readonly IContactoRepository dataService = new ContactoService();

	public NuevoContactoPage()
	{
		InitializeComponent();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		contacto = BindingContext as Contacto;
		//Control de edicion
		if (contacto != null)
		{
			Nombre.Text = contacto.Nombre;
			Apellido.Text = contacto.Apellido;
			Cedula.Text = contacto.Cedula;
			Direccion.Text = contacto.Direccion;
			Telefono.Text = contacto.Telefono;
			Email.Text = contacto.Email;
		}
	}

	public async void OnClickGuardarContacto(object sender, EventArgs e)
	{
		this.BindingContext = this;
		if (contacto == null)
		{
			contacto = new Contacto()
			{
				Nombre = Nombre.Text,
				Apellido = Apellido.Text,
				Cedula = Cedula.Text,
				Direccion = Direccion.Text,
				Telefono = Telefono.Text,
				Email = Email.Text,
				Imagen = "https://www.gravatar.com/avatar/205e460b479e2e5b48aec07710c08d50"
			};
			await dataService.AddContactoAsync(contacto);
		}
		else
		{
			contacto.Nombre = Nombre.Text;
			contacto.Apellido = Apellido.Text;
			contacto.Cedula = Cedula.Text;
			contacto.Direccion = Direccion.Text;
			contacto.Telefono = Telefono.Text;
			contacto.Email = Email.Text;
			contacto.Imagen = contacto.Imagen;

			await dataService.UpdateContactoAsync(contacto);
			BindingContext = contacto;
		}
		await Navigation.PopAsync();	
	}


}
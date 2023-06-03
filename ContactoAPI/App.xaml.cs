using ContactoAPI.Services;

namespace ContactoAPI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new ContactosPage());

	}
}

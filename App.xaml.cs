using MonkeyCache.LiteDB;

namespace Lembrador;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		Barrel.ApplicationId = "lembrador";

		MainPage = new AppShell();
	}
}

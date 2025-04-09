namespace survival_island_2;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
	}

	protected override Window CreateWindow(IActivationState? activationState)
	{

		return new Window(new AppShell())
		{
			Width = 1280,
      Height = 720
    };
	}
}
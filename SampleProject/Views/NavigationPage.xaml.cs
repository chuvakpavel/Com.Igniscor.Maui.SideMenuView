using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class NavigationPage
{
	public NavigationPage()
	{
		InitializeComponent();

        BindingContext = new NavigationViewModel();

    }
}
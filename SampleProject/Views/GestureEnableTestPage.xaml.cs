using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class GestureEnableTestPage
{
	public GestureEnableTestPage()
	{
		InitializeComponent();

        BindingContext = new ExperimentalViewModel();
    }
}
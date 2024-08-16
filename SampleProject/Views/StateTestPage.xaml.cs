using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class StateTestPage
{
	public StateTestPage()
	{
		InitializeComponent();
        BindingContext = new ExperimentalViewModel();
    }
}
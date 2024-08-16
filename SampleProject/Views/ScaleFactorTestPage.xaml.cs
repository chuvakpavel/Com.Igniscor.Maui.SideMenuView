using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class ScaleFactorTestPage
{
	public ScaleFactorTestPage()
	{
		InitializeComponent();

        BindingContext = new ExperimentalViewModel();
    }
}
using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class OpacityFactorTestPage
{
	public OpacityFactorTestPage()
	{
		InitializeComponent();

        BindingContext = new ExperimentalViewModel();
    }
}
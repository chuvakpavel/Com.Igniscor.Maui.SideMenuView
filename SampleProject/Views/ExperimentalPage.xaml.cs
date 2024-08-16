using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class ExperimentalPage
{
	public ExperimentalPage()
	{
		InitializeComponent();

        BindingContext = new ExperimentalViewModel();
    }
}
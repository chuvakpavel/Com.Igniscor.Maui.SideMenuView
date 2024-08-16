using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class ParallaxTestPage
{
	public ParallaxTestPage()
	{
		InitializeComponent();

        BindingContext = new ExperimentalViewModel();
    }
}
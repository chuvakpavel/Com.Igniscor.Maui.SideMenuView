using SampleProject.ViewModels;

namespace SampleProject.Views;

public partial class SideMenuViewListPage
{
    public SideMenuViewListPage()
    {
        InitializeComponent();

        BindingContext = new SideMenuViewListViewModel();
    }
}
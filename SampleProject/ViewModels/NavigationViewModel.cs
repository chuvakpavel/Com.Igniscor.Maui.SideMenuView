using SampleProject.Abstractions;
using SampleProject.Models;
using SampleProject.Views;

namespace SampleProject.ViewModels;

class NavigationViewModel : BaseNavigationViewModel
{
    public NavigationViewModel()
    {
        Items = new List<NavigationButtonItem>
        {
            new(Helpers.Constants.Texts.StateTestPageTitle, nameof(StateTestPage),
                Helpers.Constants.Texts.StateTestPageTitleDescription),
            new(Helpers.Constants.Texts.GestureEnableTestPageTitle, nameof(GestureEnableTestPage),
                Helpers.Constants.Texts.GestureEnableTestPageDescription),
            new(Helpers.Constants.Texts.ParallaxTestPageTitle, nameof(ParallaxTestPage),
                Helpers.Constants.Texts.ParallaxTestPageDescription),
            new(Helpers.Constants.Texts.OpacityFactorTestPageTitle, nameof(OpacityFactorTestPage),
                Helpers.Constants.Texts.OpacityFactorTestPageDescription),
            new(Helpers.Constants.Texts.ScaleFactorTestPageTitle, nameof(ScaleFactorTestPage),
                Helpers.Constants.Texts.ScaleFactorTestPageDescription),
            new(Helpers.Constants.Texts.SideMenuViewListPageTitle, nameof(SideMenuViewListPage),
                Helpers.Constants.Texts.SideMenuViewListPageTitleDescription),
            new(Helpers.Constants.Texts.ExperimentalPageTitle, nameof(ExperimentalPage),
                Helpers.Constants.Texts.ExperimentalPageDescription),
        };
    }
}
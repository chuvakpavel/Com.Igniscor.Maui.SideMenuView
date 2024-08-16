using SampleProject.Views;

namespace SampleProject;

public partial class AppShell
{
    public AppShell()
    {
        if (Application.Current != null) Application.Current.UserAppTheme = AppTheme.Light;
        InitializeComponent();
        Routing.RegisterRoute(nameof(StateTestPage), typeof(StateTestPage));
        Routing.RegisterRoute(nameof(GestureEnableTestPage), typeof(GestureEnableTestPage));
        Routing.RegisterRoute(nameof(ParallaxTestPage), typeof(ParallaxTestPage));
        Routing.RegisterRoute(nameof(OpacityFactorTestPage), typeof(OpacityFactorTestPage));
        Routing.RegisterRoute(nameof(ScaleFactorTestPage), typeof(ScaleFactorTestPage));
        Routing.RegisterRoute(nameof(ExperimentalPage), typeof(ExperimentalPage));
        Routing.RegisterRoute(nameof(SideMenuViewListPage), typeof(SideMenuViewListPage));
    }
}
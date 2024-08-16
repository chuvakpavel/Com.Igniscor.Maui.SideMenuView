using Com.Igniscor.Maui.SideMenu.Handlers;
using Com.Igniscor.Maui.SideMenu.Views;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace Com.Igniscor.Maui.SideMenu;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder UseSideMenuControl(this MauiAppBuilder builder)
    {
        builder
            .UseMauiCompatibility()
            .ConfigureMauiHandlers(handlers =>
        {
            handlers.AddHandler(typeof(SideMenuView), typeof(SideMenuViewRenderer));
        });

        return builder;
    }
}
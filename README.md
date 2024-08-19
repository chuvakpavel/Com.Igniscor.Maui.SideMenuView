# Com.Igniscor.Maui.SideMenuView
 Side Menu View for Maui (Android, iOS). Ported from XamarinCommunityToolkit (https://github.com/xamarin/XamarinCommunityToolkit/tree/main/src/CommunityToolkit/Xamarin.CommunityToolkit/Views/SideMenuView).
***

# Example
![AndroidSideMenuViewDemo](https://github.com/chuvakpavel/Com.Igniscor.Maui.SideMenuView/blob/main/ReadMeFiles/SideMenuViewAndroid.gif)
![iOSSideMenuViewDemo](https://github.com/chuvakpavel/Com.Igniscor.Maui.SideMenuView/blob/main/ReadMeFiles/SideMenuViewiOS.gif)
```Xaml
    <views:SideMenuView State="{Binding SideMenuState}">

        <VerticalStackLayout
            views:SideMenuView.Position="LeftMenu"
            views:SideMenuView.MenuAppearanceType="SlideIn"
            views:SideMenuView.MenuWidthPercentage="0.5"
            views:SideMenuView.MainViewScaleFactor="{Binding MainViewScaleFactor}"
            views:SideMenuView.MainViewOpacityFactor="{Binding MainViewOpacityFactor}"
            views:SideMenuView.MenuGestureEnabled="{Binding MenuGestureEnabled}"
            views:SideMenuView.ParallaxValue="{Binding ParallaxValue}"
            BackgroundColor="{StaticResource PrimaryDark}">

            <Label Text="{x:Static helpers:Constants+Texts.SlideInAnimation}" />
        </VerticalStackLayout>

        <VerticalStackLayout
            views:SideMenuView.Position="RightMenu"
            views:SideMenuView.MenuAppearanceType="SlideIn"
            views:SideMenuView.MenuWidthPercentage="0.5"
            views:SideMenuView.MainViewScaleFactor="{Binding MainViewScaleFactor}"
            views:SideMenuView.MainViewOpacityFactor="{Binding MainViewOpacityFactor}"
            views:SideMenuView.MenuGestureEnabled="{Binding MenuGestureEnabled}"
            views:SideMenuView.ParallaxValue="{Binding ParallaxValue}"
            BackgroundColor="{StaticResource PrimaryDark}">

            <Label Text="{x:Static helpers:Constants+Texts.SlideInAnimation}" />
        </VerticalStackLayout>

        <VerticalStackLayout
            BackgroundColor="{StaticResource Tertiary}"
            views:SideMenuView.Position="MainView">

            <Label
                HorizontalOptions="Center"
                Text="{x:Static helpers:Constants+Texts.TestText}"
                FontSize="Large" />

            <Label
                HorizontalOptions="Center"
                Text="{x:Static helpers:Constants+Texts.TestText}"
                FontSize="Medium" />

            <Label
                HorizontalOptions="Center"
                Text="{x:Static helpers:Constants+Texts.TestText}"
                FontSize="Small" />
        </VerticalStackLayout>
    </views:SideMenuView>
</Border>
```
***

# Usage SideMenuView
Available on **NuGet**: https://www.nuget.org/packages/Xamarin.CommunityToolkit

Install into your cross-platform project.
``` c#
using Com.Igniscor.Maui.SideMenu;
...

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSideMenuControl()
...
```
***

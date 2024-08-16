using System.Windows.Input;
using Com.Igniscor.Maui.SideMenu.Enums;
using SampleProject.Abstractions;
using static SampleProject.Helpers.Constants;

namespace SampleProject.ViewModels;

internal class ExperimentalViewModel : BaseViewModel
{
    public ICommand MenuGestureEnabledCommand { get; private set; }
    public ICommand MenuGestureDisableCommand { get; private set; }
    public ICommand SetSideMenuLeftStateCommand { get; private set; }
    public ICommand SetSideMenuMainStateCommand { get; private set; }
    public ICommand SetSideMenuRightCommand { get; private set; }

    public string GetGestureState => $"{Texts.CurrentState}: {MenuGestureEnabled}";
    public string GetMenuState => $"{Texts.CurrentState}: {SideMenuState}";

    public SideMenuState SideMenuState { get; set; } = SideMenuState.MainViewShown;

    public bool MenuGestureEnabled { get; set; } = true;

    public double MainViewOpacityFactor { get; set; } = 1.0d;

    public double MainViewScaleFactor { get; set; } = 1.0d;

    public double ParallaxValue { get; set; }

    public ExperimentalViewModel()
    {
        MenuGestureDisableCommand = new Command(() => MenuGestureEnabled = false);
        MenuGestureEnabledCommand = new Command(() => MenuGestureEnabled = true);
        SetSideMenuLeftStateCommand = new Command(() => SideMenuState = SideMenuState.LeftMenuShown);
        SetSideMenuMainStateCommand= new Command(() => SideMenuState = SideMenuState.MainViewShown);
        SetSideMenuRightCommand = new Command(() => SideMenuState = SideMenuState.RightMenuShown);
    }
}
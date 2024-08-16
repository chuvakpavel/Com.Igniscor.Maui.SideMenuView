using Com.Igniscor.Maui.SideMenu.Enums;
using SampleProject.Abstractions;

namespace SampleProject.Models;

internal class ListOfSideMenuItem : BaseViewModel
{
    public SideMenuState SideMenuState { get; set; } = SideMenuState.MainViewShown;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
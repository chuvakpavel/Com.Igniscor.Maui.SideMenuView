using System.Collections.ObjectModel;
using System.Windows.Input;
using Com.Igniscor.Maui.SideMenu.Enums;
using SampleProject.Abstractions;
using SampleProject.Models;
using SampleProject.Helpers;

namespace SampleProject.ViewModels;

internal class SideMenuViewListViewModel : BaseViewModel
{
    public ObservableCollection<ListOfSideMenuItem> Collection { get; set; }

    public ICommand OnTapCommand { get; set; }

    public SideMenuViewListViewModel()
    {
        Collection = new ObservableCollection<ListOfSideMenuItem>();
        OnTapCommand = new Command<object>(OnTap);
        Task.Run(Init);
    }

    private async Task Init()
    {
        var list = new List<ListOfSideMenuItem>();
        for (var i = 0; i < 100; i++)
        {
            var item = new ListOfSideMenuItem
            {
                Name = Constants.Texts.TestText,
                Description = Constants.Texts.TestDescription,
                SideMenuState = SideMenuState.MainViewShown
            };
            list.Add(item);
        }

        await MainThread.InvokeOnMainThreadAsync(() =>
            Collection = new ObservableCollection<ListOfSideMenuItem>(list));
    }


    private static void OnTap(object obj)
    {
        var item = obj as ListOfSideMenuItem;

        if (item is { SideMenuState: SideMenuState.LeftMenuShown })
        {
            item.SideMenuState = SideMenuState.MainViewShown;
        }
        else if (item is { SideMenuState: SideMenuState.MainViewShown })
        {
            item.SideMenuState = SideMenuState.LeftMenuShown;
        }
    }
}
using Com.Igniscor.Maui.SideMenu.Enums;

namespace Com.Igniscor.Maui.SideMenu.Interface;

public interface ISideMenuList<T> : IList<T> where T : View
{
    void Add(View view, SideMenuPosition position);

    void Add(View view, SideMenuPosition position, double menuWidthPercentage);

    void AddMainView(View view);

    void AddMainView(View view, double menuWidthPercentage);

    void AddLeftMenu(View view);

    void AddLeftMenu(View view, double menuWidthPercentage);

    void AddRightMenu(View view);

    void AddRightMenu(View view, double menuWidthPercentage);
}
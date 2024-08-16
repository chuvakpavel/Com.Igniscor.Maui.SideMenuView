namespace SampleProject.Views.Support;

public partial class BasePropertyView
{
    #region Bindable Properties

    #region InnerView Property

    public static readonly BindableProperty InnerViewProperty = BindableProperty.Create(
        nameof(InnerView),
        typeof(View),
        typeof(BasePropertyView),
        propertyChanged: InnerView_OnPropertyChanged);

    public View InnerView
    {
        get => (View)GetValue(InnerViewProperty);
        set => SetValue(InnerViewProperty, value);
    }

    private static void InnerView_OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not BasePropertyView view || newValue is not View innerView)
        {
            return;
        }

        view.InnerViewGrid.Children.Clear();
        view.InnerViewGrid.Children.Add(innerView);
    }

    #endregion InnerView Property

    #region Title Property

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(BasePropertyView));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion Title Property

    #endregion Bindable Properties

    public BasePropertyView()
    {
        InitializeComponent();
    }
}
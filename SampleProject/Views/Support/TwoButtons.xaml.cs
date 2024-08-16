using System.Windows.Input;

namespace SampleProject.Views.Support;

public partial class TwoButtons
{
    #region Bindable Properties

    #region Title Property

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(TwoButtons));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    #endregion Title Property

    #region PositiveButtonText Property

    public static readonly BindableProperty PositiveButtonTextProperty = BindableProperty.Create(
        nameof(PositiveButtonText),
        typeof(string),
        typeof(TwoButtons));

    public string PositiveButtonText
    {
        get => (string)GetValue(PositiveButtonTextProperty);
        set => SetValue(PositiveButtonTextProperty, value);
    }

    #endregion PositiveButtonText Property

    #region NegativeButtonText Property

    public static readonly BindableProperty NegativeButtonTextProperty = BindableProperty.Create(
        nameof(NegativeButtonText),
        typeof(string),
        typeof(TwoButtons));

    public string NegativeButtonText
    {
        get => (string)GetValue(NegativeButtonTextProperty);
        set => SetValue(NegativeButtonTextProperty, value);
    }

    #endregion NegativeButtonText Property

    #region PositiveCommand Property

    public static readonly BindableProperty PositiveCommandProperty = BindableProperty.Create(
        nameof(PositiveCommand),
        typeof(ICommand),
        typeof(TwoButtons));

    public ICommand PositiveCommand
    {
        get => (ICommand)GetValue(PositiveCommandProperty);
        set => SetValue(PositiveCommandProperty, value);
    }

    #endregion PositiveCommand  Property

    #region NegativeCommand Property

    public static readonly BindableProperty NegativeCommandProperty = BindableProperty.Create(
        nameof(NegativeCommand),
        typeof(ICommand),
        typeof(TwoButtons));

    public ICommand NegativeCommand
    {
        get => (ICommand)GetValue(NegativeCommandProperty);
        set => SetValue(NegativeCommandProperty, value);
    }

    #endregion NegativeCommand  Property

    #endregion Bindable Properties

    public TwoButtons()
    {
        InitializeComponent();
    }
}
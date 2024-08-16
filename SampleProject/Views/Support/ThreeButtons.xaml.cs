using System.Windows.Input;

namespace SampleProject.Views.Support;

public partial class ThreeButtons
{
    #region Bindable Properties

    #region Title Property

    public static readonly BindableProperty TitleProperty = BindableProperty.Create(
        nameof(Title),
        typeof(string),
        typeof(ThreeButtons));

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
        typeof(ThreeButtons));

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
        typeof(ThreeButtons));

    public string NegativeButtonText
    {
        get => (string)GetValue(NegativeButtonTextProperty);
        set => SetValue(NegativeButtonTextProperty, value);
    }

    #endregion NegativeButtonText Property

    #region MiddleButtonText Property

    public static readonly BindableProperty MiddleButtonTextProperty = BindableProperty.Create(
        nameof(MiddleButtonText),
        typeof(string),
        typeof(ThreeButtons));

    public string MiddleButtonText
    {
        get => (string)GetValue(MiddleButtonTextProperty);
        set => SetValue(MiddleButtonTextProperty, value);
    }

    #endregion MiddleButtonText Property

    #region PositiveCommand Property

    public static readonly BindableProperty PositiveCommandProperty = BindableProperty.Create(
        nameof(PositiveCommand),
        typeof(ICommand),
        typeof(ThreeButtons));

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
        typeof(ThreeButtons));

    public ICommand NegativeCommand
    {
        get => (ICommand)GetValue(NegativeCommandProperty);
        set => SetValue(NegativeCommandProperty, value);
    }

    #endregion NegativeCommand  Property

    #region MiddleCommand Property

    public static readonly BindableProperty MiddleCommandProperty = BindableProperty.Create(
        nameof(MiddleCommand),
        typeof(ICommand),
        typeof(ThreeButtons));

    public ICommand MiddleCommand
    {
        get => (ICommand)GetValue(MiddleCommandProperty);
        set => SetValue(MiddleCommandProperty, value);
    }

    #endregion MiddleCommand Property

    #endregion Bindable Properties


    public ThreeButtons()
    {
        InitializeComponent();
    }
}
using Microsoft.Maui.Layouts;
using System.Collections;
using System.Collections.Specialized;
using Com.Igniscor.Maui.SideMenu.Abstractions;
using Com.Igniscor.Maui.SideMenu.Enums;
using Com.Igniscor.Maui.SideMenu.Handlers;
using Com.Igniscor.Maui.SideMenu.Interface;
using Com.Igniscor.Maui.SideMenu.Models;
using static Microsoft.Maui.Controls.Compatibility.AbsoluteLayout;
using static System.Math;
using AbsoluteLayout = Microsoft.Maui.Controls.Compatibility.AbsoluteLayout;


namespace Com.Igniscor.Maui.SideMenu.Views;

[ContentProperty(nameof(Children))]
public sealed class SideMenuView : BaseTemplatedView<AbsoluteLayout>
{
    #region BindableProperties

    #region Shift Property

    public static readonly BindableProperty ShiftProperty =
        BindableProperty.Create(
            nameof(Shift),
            typeof(double),
            typeof(SideMenuView),
            0.0,
            BindingMode.OneWayToSource);

    public double Shift
    {
        get => (double)GetValue(ShiftProperty);
        set => SetValue(ShiftProperty, value);
    }

    #endregion Shift Property

    #region CurrentGestureShift Property

    public static readonly BindableProperty CurrentGestureShiftProperty
        = BindableProperty.Create(
            nameof(CurrentGestureShift),
            typeof(double),
            typeof(SideMenuView), 0.0,
            BindingMode.OneWayToSource);

    public double CurrentGestureShift
    {
        get => (double)GetValue(CurrentGestureShiftProperty);
        set => SetValue(CurrentGestureShiftProperty, value);
    }

    #endregion CurrentGestureShift Property

    #region CurrentGestureState Property

    public static readonly BindableProperty CurrentGestureStateProperty
        = BindableProperty.Create(
            nameof(CurrentGestureState),
            typeof(SideMenuState),
            typeof(SideMenuView),
            SideMenuState.MainViewShown,
            BindingMode.OneWayToSource);

    public SideMenuState CurrentGestureState
    {
        get => (SideMenuState)GetValue(CurrentGestureStateProperty);
        set => SetValue(CurrentGestureStateProperty, value);
    }

    #endregion CurrentGestureState Property

    #region GestureThreshold Property

    public static readonly BindableProperty GestureThresholdProperty =
        BindableProperty.Create(
            nameof(GestureThreshold),
            typeof(double),
            typeof(SideMenuView),
            -1.0);

    public double GestureThreshold
    {
        get => (double)GetValue(GestureThresholdProperty);
        set => SetValue(GestureThresholdProperty, value);
    }

    #endregion GestureThreshold Property

    #region CancelVerticalGestureThreshold Property

    public static readonly BindableProperty CancelVerticalGestureThresholdProperty =
        BindableProperty.Create(
            nameof(CancelVerticalGestureThreshold),
            typeof(double),
            typeof(SideMenuView),
            1.0);

    public double CancelVerticalGestureThreshold
    {
        get => (double)GetValue(CancelVerticalGestureThresholdProperty);
        set => SetValue(CancelVerticalGestureThresholdProperty, value);
    }

    #endregion CancelVerticalGestureThreshold Property

    #region MenuGestureEnabled Property

    public static readonly BindableProperty MenuGestureEnabledProperty
        = BindableProperty.CreateAttached(
            nameof(GetMenuGestureEnabled),
            typeof(bool),
            typeof(SideMenuView),
            true);

    public static bool GetMenuGestureEnabled(BindableObject bindable)
        => (bool)bindable.GetValue(MenuGestureEnabledProperty);

    public static void SetMenuGestureEnabled(BindableObject bindable, bool value)
        => bindable.SetValue(MenuGestureEnabledProperty, value);
    #endregion MenuGestureEnabled Property

    #region State Property

    public static readonly BindableProperty StateProperty =
        BindableProperty.Create(
            nameof(State),
            typeof(SideMenuState),
            typeof(SideMenuView),
            SideMenuState.MainViewShown,
            BindingMode.TwoWay,
            propertyChanged: OnStatePropertyChanged);

    public SideMenuState State
    {
        get => (SideMenuState)GetValue(StateProperty);
        set => SetValue(StateProperty, value);
    }

    #endregion State Property

    #region Position Property

    public static readonly BindableProperty PositionProperty
        = BindableProperty.CreateAttached(
            nameof(GetPosition),
            typeof(SideMenuPosition),
            typeof(SideMenuView),
            SideMenuPosition.MainView);

    public static SideMenuPosition GetPosition(BindableObject bindable)
        => (SideMenuPosition)bindable.GetValue(PositionProperty);

    public static void SetPosition(BindableObject bindable, SideMenuPosition value)
        => bindable.SetValue(PositionProperty, value);

    #endregion Position Property

    #region MenuAppearanceType Property

    public static readonly BindableProperty MenuAppearanceTypeProperty
        = BindableProperty.CreateAttached(
            nameof(GetMenuAppearanceType),
            typeof(SideMenuAppearanceType),
            typeof(SideMenuView),
            SideMenuAppearanceType.SlideOut);

    public static SideMenuAppearanceType GetMenuAppearanceType(BindableObject bindable)
        => (SideMenuAppearanceType)bindable.GetValue(MenuAppearanceTypeProperty);

    public static void SetMenuAppearanceType(BindableObject bindable, SideMenuAppearanceType value)
        => bindable.SetValue(MenuAppearanceTypeProperty, value);

    #endregion MenuAppearanceType Property

    #region MenuWidthPercentage Property

    public static readonly BindableProperty MenuWidthPercentageProperty
        = BindableProperty.CreateAttached(
            nameof(GetMenuWidthPercentage),
            typeof(double),
            typeof(SideMenuView),
            -1.0);

    public static double GetMenuWidthPercentage(BindableObject bindable)
        => (double)bindable.GetValue(MenuWidthPercentageProperty);

    public static void SetMenuWidthPercentage(BindableObject bindable, double value)
        => bindable.SetValue(MenuWidthPercentageProperty, value);

    #endregion MenuWidthPercentage Property

    #region MainViewScaleFactor Property

    public static readonly BindableProperty MainViewScaleFactorProperty
        = BindableProperty.CreateAttached(
            nameof(GetMainViewScaleFactor),
            typeof(double),
            typeof(SideMenuView),
            1.0);

    public static double GetMainViewScaleFactor(BindableObject bindable)
        => (double)bindable.GetValue(MainViewScaleFactorProperty);

    public static void SetMainViewScaleFactor(BindableObject bindable, double value)
        => bindable.SetValue(MainViewScaleFactorProperty, value);

    #endregion MainViewScaleFactor Property

    #region MainViewOpacityFactor Property

    public static readonly BindableProperty MainViewOpacityFactorProperty
        = BindableProperty.CreateAttached(
            nameof(GetMainViewOpacityFactor),
            typeof(double), typeof(SideMenuView),
            1.0);

    public static double GetMainViewOpacityFactor(BindableObject bindable)
        => (double)bindable.GetValue(MainViewOpacityFactorProperty);

    public static void SetMainViewOpacityFactor(BindableObject bindable, double value)
        => bindable.SetValue(MainViewOpacityFactorProperty, value);

    #endregion MainViewOpacityFactor Property

    #region ParallaxValue Property

    public static readonly BindableProperty ParallaxValueProperty
        = BindableProperty.CreateAttached(
            nameof(GetParallaxValue),
            typeof(double),
            typeof(SideMenuView),
            0.0);

    public static double GetParallaxValue(BindableObject bindable)
        => (double)bindable.GetValue(ParallaxValueProperty);

    public static void SetParallaxValue(BindableObject bindable, double value)
        => bindable.SetValue(ParallaxValueProperty, value);

    #endregion ParallaxValue Property

    #endregion BindableProperties

    const string AnimationName = nameof(SideMenuView);

    const uint AnimationRate = 16;

    const uint AnimationLength = 350;

    const int MaxTimeShiftItemsCount = 24;

    const int MinSwipeTimeShiftItemsCount = 2;

    const double SwipeThresholdDistance = 17;

    const double AcceptMoveThresholdPercentage = 0.3;

    const uint SwipeAnimationAccelerationFactor = 2;

    static readonly Easing AnimationEasing = Easing.SinOut;

    static readonly TimeSpan SwipeThresholdTime =
        TimeSpan.FromMilliseconds(DeviceInfo.Current.Platform == DevicePlatform.Android ? 100 : 60);

    readonly List<TimeShiftItem> _timeShiftItems = new List<TimeShiftItem>();

    readonly SideMenuElementCollection _children = new SideMenuElementCollection();

    View? _overlayView, _mainView, _leftMenu, _rightMenu, _activeMenu, _inactiveMenu;

    double _zeroShift;

    bool _isGestureStarted;

    bool _isGestureDirectionResolved;

    bool _isSwipe;

    double _previousShift;

    public SideMenuView()
    {
        #region Required work-around to prevent linker from removing the platform-specific implementation

#if __ANDROID__
        if (DateTime.Now.Ticks < 0)
            _ = new SideMenuViewRenderer(Platform.AppContext?? throw new NullReferenceException());
#elif __IOS__
        if (DateTime.Now.Ticks < 0)
            _ = new SideMenuViewRenderer();
#endif

        #endregion
    }

    public new ISideMenuList<View> Children
        => _children;

    internal void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
    {
        var shift = e.TotalX;
        var verticalShift = e.TotalY;
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                OnTouchStarted();
                return;
            case GestureStatus.Running:
                OnTouchChanged(shift, verticalShift);
                return;
            case GestureStatus.Canceled:
            case GestureStatus.Completed:
#if __ANDROID__
                OnTouchChanged(shift, verticalShift);
#endif

                OnTouchEnded();
                return;
        }
    }

    internal async void OnSwiped(SwipeDirection swipeDirection)
    {
        await Task.Delay(1);
        if (_isGestureStarted)
            return;

        var state = ResolveSwipeState(swipeDirection == SwipeDirection.Right);
        UpdateState(state, true);
    }

    internal bool CheckGestureEnabled(SideMenuPosition menuPosition)
        => menuPosition switch
        {
            SideMenuPosition.LeftMenu => CheckMenuGestureEnabled(_leftMenu),
            SideMenuPosition.RightMenu => CheckMenuGestureEnabled(_rightMenu),
            _ => true
        };

    protected override void OnControlInitialized(AbsoluteLayout control)
    {
        _children.CollectionChanged += OnChildrenCollectionChanged;

        _overlayView = SetupMainViewLayout(new ContentView()
        {
            InputTransparent = true,
        });

#if !__ANDROID__
        var panGestureRecognizer = new PanGestureRecognizer();
        panGestureRecognizer.PanUpdated += OnPanUpdated;
        GestureRecognizers.Add(panGestureRecognizer);
#endif
        control.Children.Add(_overlayView);
        control.LayoutChanged += OnLayoutChanged;
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        PerformUpdate(false);
    }

    static View SetupMainViewLayout(View view)
    {
        SetLayoutFlags(view, AbsoluteLayoutFlags.All);
        SetLayoutBounds(view, new Rect(0, 0, 1, 1));
        return view;
    }

    static View SetupMenuLayout(View view, bool isLeft)
    {
        var width = GetMenuWidthPercentage(view);
        var flags = width > 0
            ? AbsoluteLayoutFlags.All
            : AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.HeightProportional;
        SetLayoutFlags(view, flags);
        SetLayoutBounds(view, new Rect(isLeft ? 0 : 1, 0, width, 1));
        return view;
    }

    static void OnStatePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        => ((SideMenuView)bindable).OnStatePropertyChanged();

    void OnStatePropertyChanged()
        => PerformUpdate(true);

    void OnTouchStarted()
    {
        if (_isGestureStarted)
            return;

        _isGestureDirectionResolved = false;
        _isGestureStarted = true;
        _zeroShift = 0;
        PopulateTimeShiftItems(0);
    }


    void OnTouchChanged(double shift, double verticalShift)
    {
        if (!_isGestureStarted || Abs(CurrentGestureShift - shift) <= double.Epsilon)
            return;

        PopulateTimeShiftItems(shift);
        var absShift = Abs(shift);
        var absVerticalShift = Abs(verticalShift);
        if (!_isGestureDirectionResolved && Max(absShift, absVerticalShift) > CancelVerticalGestureThreshold)
        {
            absVerticalShift *= 2.5;
            if (absVerticalShift >= absShift)
            {
                _isGestureStarted = false;
                OnTouchEnded();
                return;
            }

            _isGestureDirectionResolved = true;
        }

        _mainView.AbortAnimation(AnimationName);
        var totalShift = _previousShift + shift;
        if (!TryUpdateShift(totalShift - _zeroShift, true))
            _zeroShift = totalShift - Shift;
    }

    void OnTouchEnded()
    {
        if (!_isGestureStarted)
            return;

        _isGestureStarted = false;
        CleanTimeShiftItems();

        _previousShift = Shift;
        var state = State;
        var isSwipe = TryResolveFlingGesture(ref state);
        PopulateTimeShiftItems(0);
        _timeShiftItems.Clear();
        UpdateState(state, isSwipe);
    }

    void PerformUpdate(bool isAnimated)
    {
        var state = State;
        var start = Shift;
        var menuWidth = (state == SideMenuState.LeftMenuShown ? _leftMenu : _rightMenu)?.Width ?? 0;
        var end = -Sign((int)state) * menuWidth;

        if (!isAnimated)
        {
            TryUpdateShift(end, false);
            SetOverlayViewInputTransparent(state);
            return;
        }

        var animationLength = (uint)(SideMenuView.AnimationLength * Abs(start - end) / Width);
        if (_isSwipe)
        {
            _isSwipe = false;
            animationLength /= SwipeAnimationAccelerationFactor;
        }

        if (animationLength == 0)
        {
            SetOverlayViewInputTransparent(state);
            return;
        }

        var animation = new Animation(v => TryUpdateShift(v, false), Shift, end);
        _mainView.Animate(AnimationName, animation, AnimationRate, animationLength, AnimationEasing, (_, isCanceled) =>
        {
            if (isCanceled)
                return;

            SetOverlayViewInputTransparent(state);
        });
    }

    void SetOverlayViewInputTransparent(SideMenuState state)
    {
        _ = _overlayView ?? throw new NullReferenceException();
        _overlayView.InputTransparent = state == SideMenuState.MainViewShown;
    }

    SideMenuState ResolveSwipeState(bool isRightSwipe)
    {
        var left = SideMenuState.LeftMenuShown;
        var right = SideMenuState.RightMenuShown;
        switch (State)
        {
            case SideMenuState.LeftMenuShown:
                right = SideMenuState.MainViewShown;
                SetActiveView(true);
                break;
            case SideMenuState.RightMenuShown:
                left = SideMenuState.MainViewShown;
                SetActiveView(false);
                break;
        }

        return isRightSwipe ? left : right;
    }

    bool TryUpdateShift(double shift, bool isUserInteraction)
    {
        var isLeft = shift >= 0;
        SetActiveView(isLeft);
        if (_activeMenu == null)
            return false;

        if (isUserInteraction && !GetMenuGestureEnabled(_activeMenu))
            return false;

        _ = _mainView ?? throw new NullReferenceException();

        var activeMenuWidth = _activeMenu.Width;
        var mainViewWidth = _mainView.Width;

        var sign = Sign(shift);
        shift = sign * Min(Abs(shift), activeMenuWidth);
        if (isUserInteraction && Abs(Shift - shift) <= double.Epsilon)
            return false;

        var nonZeroSign = isLeft ? -1 : 1;

        Shift = shift;
        SetCurrentGestureState(shift);
        if (!isUserInteraction)
            _previousShift = shift;

        _ = _overlayView ?? throw new NullReferenceException();

        using (_mainView.Batch())
        using (_activeMenu.Batch())
        using (_overlayView.Batch())
        using (_inactiveMenu?.Batch())
        {
            if (_inactiveMenu != null)
                _inactiveMenu.TranslationX = -_inactiveMenu.Width * nonZeroSign;

            var progress = AnimationEasing.Ease(Abs(shift) / activeMenuWidth);
            var scale = 1 - ((1 - GetMainViewScaleFactor(_activeMenu)) * progress);
            var opacity = 1 - ((1 - GetMainViewOpacityFactor(_activeMenu)) * progress);

            var parallax = GetParallaxValue(_activeMenu);
            parallax = Min(Abs(parallax), activeMenuWidth) * Sign(parallax);

            _mainView.Scale = scale;
            _mainView.Opacity = opacity;

            switch (GetMenuAppearanceType(_activeMenu))
            {
                case SideMenuAppearanceType.SlideOut:
                    _activeMenu.TranslationX = parallax * (1 - progress) * nonZeroSign;
                    _mainView.TranslationX = shift - (sign * mainViewWidth * 0.5 * (1 - scale));
                    _overlayView.TranslationX = shift;
                    break;
                case SideMenuAppearanceType.SlideIn:
                    _activeMenu.TranslationX = (activeMenuWidth - Abs(shift)) * nonZeroSign;
                    _mainView.TranslationX = parallax * nonZeroSign * progress;
                    _overlayView.TranslationX = parallax * nonZeroSign * progress;
                    break;
                case SideMenuAppearanceType.SlideInOut:
                    _activeMenu.TranslationX =
                        (activeMenuWidth - Abs(shift) - (parallax * (1 - progress))) * nonZeroSign;
                    _mainView.TranslationX = shift - (sign * mainViewWidth * 0.5 * (1 - scale));
                    _overlayView.TranslationX = shift;
                    break;
            }
        }

        return true;
    }

    void SetCurrentGestureState(double shift)
    {
        var menuWidth = _activeMenu?.Width ?? Width;
        var moveThreshold = menuWidth * AcceptMoveThresholdPercentage;
        var absShift = Abs(shift);
        var state = State;
        if (Sign(shift) != -(int)state)
            state = SideMenuState.MainViewShown;

        if ((state == SideMenuState.MainViewShown && absShift <= moveThreshold) ||
            (state != SideMenuState.MainViewShown && absShift < menuWidth - moveThreshold))
        {
            CurrentGestureState = SideMenuState.MainViewShown;
            return;
        }

        if (shift >= 0)
        {
            CurrentGestureState = SideMenuState.LeftMenuShown;
            return;
        }

        CurrentGestureState = SideMenuState.RightMenuShown;
    }

    void UpdateState(SideMenuState state, bool isSwipe)
    {
        if (!CheckMenuGestureEnabled(state))
            return;

        this._isSwipe = isSwipe;
        if (State == state)
        {
            PerformUpdate(true);
            return;
        }

        State = state;
    }

    void SetActiveView(bool isLeft)
    {
        if (isLeft)
        {
            _activeMenu = _leftMenu;
            _inactiveMenu = _rightMenu;
            return;
        }

        _activeMenu = _rightMenu;
        _inactiveMenu = _leftMenu;
    }

    bool CheckMenuGestureEnabled(SideMenuState state)
    {
        var view = state switch
        {
            SideMenuState.LeftMenuShown => _leftMenu,
            SideMenuState.RightMenuShown => _rightMenu,
            _ => _activeMenu
        };

        if (view == null)
            return false;

        return GetMenuGestureEnabled(view);
    }

    bool TryResolveFlingGesture(ref SideMenuState state)
    {
        if (state != CurrentGestureState)
        {
            state = CurrentGestureState;
            return false;
        }

        if (_timeShiftItems.Count < MinSwipeTimeShiftItemsCount)
            return false;

        var lastItem = _timeShiftItems.LastOrDefault();
        var firstItem = _timeShiftItems.FirstOrDefault();
        if (lastItem != null && firstItem != null)
        {
            var shiftDifference = lastItem.Shift - firstItem.Shift;

            if (Sign(shiftDifference) != Sign(lastItem.Shift))
                return false;

            var absShiftDifference = Abs(shiftDifference);
            var timeDifference = lastItem.Time - firstItem.Time;

            var acceptValue = SwipeThresholdDistance * timeDifference.TotalMilliseconds /
                              SwipeThresholdTime.TotalMilliseconds;

            if (absShiftDifference < acceptValue)
                return false;

            state = ResolveSwipeState(shiftDifference > 0);
        }

        return true;
    }

    void PopulateTimeShiftItems(double shift)
    {
        CurrentGestureShift = shift;

        if (_timeShiftItems.Count > MaxTimeShiftItemsCount)
            CleanTimeShiftItems();

        _timeShiftItems.Add(new TimeShiftItem(DateTime.UtcNow, shift));
    }

    void CleanTimeShiftItems()
    {
        var lastTimeShiftItem = _timeShiftItems.LastOrDefault();
        if (lastTimeShiftItem != null)
        {
            var time = lastTimeShiftItem.Time;
            for (var i = _timeShiftItems.Count - 1; i >= 0; --i)
            {
                if (time - _timeShiftItems[i].Time > SwipeThresholdTime)
                    _timeShiftItems.RemoveAt(i);
            }
        }
    }

    void OnChildrenCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null) HandleChildren(e.OldItems, RemoveChild);
        if (e.NewItems != null) HandleChildren(e.NewItems, AddChild);
    }

    void HandleChildren(IList? items, Action<View> action)
    {
        if (items != null)
        {
            foreach (var item in items)
            {
                if (item != null && action != null)
                    action((View)item);
            }
        }
    }

    void AddChild(View view)
    {
        Control?.Children.Add(view);
        switch (GetPosition(view))
        {
            case SideMenuPosition.MainView:
                _mainView = SetupMainViewLayout(view);
                break;
            case SideMenuPosition.LeftMenu:
                _leftMenu = SetupMenuLayout(view, true);
                break;
            case SideMenuPosition.RightMenu:
                _rightMenu = SetupMenuLayout(view, false);
                break;
        }
    }

    void RemoveChild(View view)
    {
        Control?.Children.Remove(view);
        switch (GetPosition(view))
        {
            case SideMenuPosition.MainView:
                _mainView = null;
                break;
            case SideMenuPosition.LeftMenu:
                _leftMenu = null;
                break;
            case SideMenuPosition.RightMenu:
                _rightMenu = null;
                break;
        }

        if (_activeMenu == view)
            _activeMenu = null;
        else if (_inactiveMenu == view)
            _inactiveMenu = null;
    }

    void RaiseMenuIfNeeded(View? menuView)
    {
        if (menuView != null && GetMenuAppearanceType(menuView) == SideMenuAppearanceType.SlideIn)
            Control?.RaiseChild(menuView);
    }

    void OnLayoutChanged(object? sender, EventArgs e)
    {
        if (_mainView == null)
            return;

        using (Control?.Batch())
        {
            Control?.RaiseChild(_mainView);
            Control?.RaiseChild(_overlayView);

            RaiseMenuIfNeeded(_leftMenu);
            RaiseMenuIfNeeded(_rightMenu);
        }
    }

    bool CheckMenuGestureEnabled(View? menuView)
        => menuView != null && GetMenuGestureEnabled(menuView);
}
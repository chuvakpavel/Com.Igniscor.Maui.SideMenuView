#if ANDROID
using Android.Content;
using Android.Views;
using Com.Igniscor.Maui.SideMenu.Handlers;
using Com.Igniscor.Maui.SideMenu.Enums;
using Com.Igniscor.Maui.SideMenu.Views;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Platform;
using static System.Math;

[assembly: ExportRenderer(typeof(SideMenuView), typeof(SideMenuViewRenderer))]

namespace Com.Igniscor.Maui.SideMenu.Handlers;

[Preserve(Conditional = true)]
public partial class SideMenuViewRenderer : VisualElementRenderer<SideMenuView>
{
    const double DefaultGestureThreshold = 30.0;

    static Guid? _lastTouchHandlerId;

    readonly float _density;

    Guid _elementId;

    bool _panStarted;

    float? _startX;

    float? _startY;

    public SideMenuViewRenderer(Context context)
        : base(context)
        => _density = context.Resources?.DisplayMetrics?.Density ?? throw new NullReferenceException();

    double GestureThreshold => Element is { GestureThreshold: >= 0 }
        ? Element.GestureThreshold
        : DefaultGestureThreshold;

    public override bool OnInterceptTouchEvent(MotionEvent? e)
    {
        if (e is { ActionMasked: MotionEventActions.Move })
        {
            if (_lastTouchHandlerId.HasValue && _lastTouchHandlerId != _elementId)
                return false;

            return CheckIsTouchHandled(GetTotalX(e), GetTotalY(e));
        }

        if (e != null) HandleDownUpEvents(e);
        return false;
    }

    public override bool OnTouchEvent(MotionEvent? e)
    {
        if (e is { ActionMasked: MotionEventActions.Move })
        {
            var xDelta = GetTotalX(e);
            var yDelta = GetTotalY(e);
            CheckIsTouchHandled(xDelta, yDelta);

            if (Abs(yDelta) <= Abs(xDelta))
                UpdatePan(GestureStatus.Running, xDelta, yDelta);
        }

        if (e != null) HandleDownUpEvents(e);
        return true;
    }

    protected override void OnElementChanged(ElementChangedEventArgs<SideMenuView> e)
    {
        base.OnElementChanged(e);
        if (e.NewElement == null)
            return;

        _panStarted = false;
        if (Element != null) _elementId = Element.Id;
    }

    bool CheckIsTouchHandled(float xDelta, float yDelta)
    {
        var xDeltaAbs = Abs(xDelta);
        var yDeltaAbs = Abs(yDelta);
        var isHandled = Element != null
                        && xDeltaAbs > yDeltaAbs
                        && xDeltaAbs > GestureThreshold
                        && ((xDelta > 0 && Element.CheckGestureEnabled(SideMenuPosition.LeftMenu))
                            || (xDelta < 0 && Element.CheckGestureEnabled(SideMenuPosition.RightMenu)));

        Parent?.RequestDisallowInterceptTouchEvent(isHandled);
        return isHandled;
    }

    void HandleDownUpEvents(MotionEvent ev)
    {
        HandleDownEvent(ev);
        HandleUpCancelEvent(ev);
    }

    void HandleUpCancelEvent(MotionEvent ev)
    {
        var action = ev.ActionMasked;
        var isUpAction = action == MotionEventActions.Up;
        var isCancelAction = action == MotionEventActions.Cancel;
        if (!_panStarted || (!isUpAction && !isCancelAction))
            return;

        var xDelta = GetTotalX(ev);
        var yDelta = GetTotalY(ev);
        UpdatePan(isUpAction ? GestureStatus.Completed : GestureStatus.Canceled, xDelta, yDelta);
        _panStarted = false;
        _lastTouchHandlerId = null;

        Parent?.RequestDisallowInterceptTouchEvent(false);

        _startX = null;
        _startY = null;
    }

    void HandleDownEvent(MotionEvent ev)
    {
        if (ev.ActionMasked != MotionEventActions.Down)
            return;

        _startX = ev.GetX();
        _startY = ev.GetY();

        UpdatePan(GestureStatus.Started);
        _panStarted = true;
        _lastTouchHandlerId = _elementId;
    }

    void UpdatePan(GestureStatus status, double totalX = 0, double totalY = 0)
        => Element?.OnPanUpdated(Element, GetPanUpdatedEventArgs(status, totalX, totalY));

    PanUpdatedEventArgs GetPanUpdatedEventArgs(GestureStatus status, double totalX = 0, double totalY = 0)
        => new PanUpdatedEventArgs(status, 0, totalX, totalY);

    float GetTotalX(MotionEvent ev)
        => (ev.GetX() - _startX.GetValueOrDefault()) / _density;

    float GetTotalY(MotionEvent ev)
        => (ev.GetY() - _startY.GetValueOrDefault()) / _density;
}
#endif
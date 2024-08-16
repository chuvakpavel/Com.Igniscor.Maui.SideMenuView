#if IOS
using Com.Igniscor.Maui.SideMenu.Handlers;
using Com.Igniscor.Maui.SideMenu.Views;
using Microsoft.Maui.Controls.Compatibility;
using Microsoft.Maui.Controls.Handlers.Compatibility;
using Microsoft.Maui.Controls.Internals;
using UIKit;
using static System.Math;

[assembly: ExportRenderer(typeof(SideMenuView), typeof(SideMenuViewRenderer))]

namespace Com.Igniscor.Maui.SideMenu.Handlers;

[Preserve(Conditional = true)]
public partial class SideMenuViewRenderer : VisualElementRenderer<SideMenuView>
{
    const double DefaultGestureThreshold = 7.0;

    UISwipeGestureRecognizer? _leftSwipeGestureRecognizer;

    UISwipeGestureRecognizer? _rightSwipeGestureRecognizer;

    public SideMenuViewRenderer()
    {
        _leftSwipeGestureRecognizer = new UISwipeGestureRecognizer(OnSwiped)
        {
            Direction = UISwipeGestureRecognizerDirection.Left
        };
        AddGestureRecognizer(_leftSwipeGestureRecognizer);
        _rightSwipeGestureRecognizer = new UISwipeGestureRecognizer(OnSwiped)
        {
            Direction = UISwipeGestureRecognizerDirection.Right
        };
        AddGestureRecognizer(_rightSwipeGestureRecognizer);
    }

    bool IsPanGestureHandled
        => Element != null && Abs(Element.CurrentGestureShift) >= GestureThreshold;

    double GestureThreshold => Element != null && Element.GestureThreshold >= 0
        ? Element.GestureThreshold
        : DefaultGestureThreshold;

    public sealed override void AddGestureRecognizer(UIGestureRecognizer gestureRecognizer)
    {
        base.AddGestureRecognizer(gestureRecognizer);

        if (gestureRecognizer is UIPanGestureRecognizer)
        {
            gestureRecognizer.ShouldBeRequiredToFailBy = ShouldBeRequiredToFailBy;
            gestureRecognizer.ShouldRecognizeSimultaneously = ShouldRecognizeSimultaneously;
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Dispose(ref _leftSwipeGestureRecognizer);
            Dispose(ref _rightSwipeGestureRecognizer);
        }

        base.Dispose(disposing);
    }

    void Dispose(ref UISwipeGestureRecognizer? gestureRecognizer)
    {
        if (gestureRecognizer != null)
        {
            RemoveGestureRecognizer(gestureRecognizer);
            gestureRecognizer.Dispose();
            gestureRecognizer = null;
        }
    }

    void OnSwiped(UISwipeGestureRecognizer gesture)
    {
        var swipeDirection = gesture.Direction == UISwipeGestureRecognizerDirection.Left
            ? SwipeDirection.Left
            : SwipeDirection.Right;

        Element?.OnSwiped(swipeDirection);
    }

    bool ShouldBeRequiredToFailBy(UIGestureRecognizer gestureRecognizer, UIGestureRecognizer otherGestureRecognizer)
        => IsPanGestureHandled && !otherGestureRecognizer.View.Equals(this);

    bool ShouldRecognizeSimultaneously(UIGestureRecognizer gestureRecognizer,
        UIGestureRecognizer otherGestureRecognizer)
    {
        if (gestureRecognizer is not UIPanGestureRecognizer panGesture)
            return true;

        var parent = Element?.Parent;
        while (parent != null)
        {
            if (parent is FlyoutPage)
            {
                var velocity = panGesture.VelocityInView(this);
                return Abs(velocity.Y) > Abs(velocity.X);
            }

            parent = parent.Parent;
        }

        return !IsPanGestureHandled;
    }
}
#endif
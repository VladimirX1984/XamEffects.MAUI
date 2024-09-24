using Android.Content;
using Android.Graphics;
using Android.Views;

using Microsoft.Maui.Controls.Platform;

using System.ComponentModel;

namespace XamEffects.Droid.Renderers
{
    public class BorderViewRenderer : Microsoft.Maui.Controls.Handlers.Compatibility.VisualElementRenderer<BorderView>
    {

        public ViewGroup ViewGroup => this;

        public static void Init()
        {
        }

        public BorderViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BorderView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement == null) return;
            BorderRendererVisual.UpdateBackground(Element, this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == BorderView.BorderColorProperty.PropertyName ||
                e.PropertyName == BorderView.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderView.CornerRadiusProperty.PropertyName ||
                e.PropertyName == VisualElement.BackgroundColorProperty.PropertyName)
            {
                BorderRendererVisual.UpdateBackground(Element, this);
            }
        }

        protected override void DispatchDraw(Canvas canvas)
        {
            canvas.Save(SaveFlags.Clip);
            BorderRendererVisual.SetClipPath(this, canvas);
            base.DispatchDraw(canvas);
            canvas.Restore();
        }
    }
}
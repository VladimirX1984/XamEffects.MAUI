using CoreAnimation;

using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;

using System.ComponentModel;

namespace XamEffects.iOS.Renderers
{
    public class BorderViewRenderer : Microsoft.Maui.Controls.Handlers.Compatibility.VisualElementRenderer<BorderView>
    {
        public static void Link()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<BorderView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;
            ClipsToBounds = true;
            Layer.AllowsEdgeAntialiasing = true;
            Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.All;
            SetCornerRadius();
            SetBorders();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == BorderView.CornerRadiusProperty.PropertyName)
                SetCornerRadius();
            else if (
                e.PropertyName == BorderView.BorderWidthProperty.PropertyName ||
                e.PropertyName == BorderView.BorderColorProperty.PropertyName)
                SetBorders();
        }

        #region Borders

        void SetCornerRadius()
        {
            if (Element == null)
            {
                return;
            }
            Layer.CornerRadius = new nfloat(Element.CornerRadius);
        }

        void SetBorders()
        {
            if (Element == null)
            {
                return;
            }
            Layer.BorderWidth = new nfloat(Element.BorderWidth);
            Layer.BorderColor = Element.BorderColor.ToCGColor();
        }

        #endregion
    }
}
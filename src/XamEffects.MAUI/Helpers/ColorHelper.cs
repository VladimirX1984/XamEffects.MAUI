namespace XamEffects.Helpers
{
    public static class ColorHelper {
        public static Color AlphaBlend(Color foreground, Color background) {
            var frontInt = new IntColor(foreground);
            var backInt = new IntColor(background);

            var alpha = frontInt.Alpha;
            if (alpha == 0x00)
                return background;
            
            var invAlpha = 0xff - alpha;
            var backAlpha = backInt.Alpha;
            if (backAlpha == 0xff) { // Opaque background case
                return Color.FromRgba(
                    (alpha * frontInt.Red + invAlpha * backInt.Red) / 0xff,
                    (alpha * frontInt.Green + invAlpha * backInt.Green) / 0xff,
                    (alpha * frontInt.Blue + invAlpha * backInt.Blue) / 0xff, 
                    0xff);
            }
            else { // General case
                backAlpha = backAlpha * invAlpha / 0xff;
                var outAlpha = alpha + backAlpha;
                return Color.FromRgba(
                    (frontInt.Red * alpha + backInt.Red * backAlpha) / outAlpha,
                    (frontInt.Green * alpha + backInt.Green * backAlpha) / outAlpha,
                    (frontInt.Blue * alpha + backInt.Blue * backAlpha) / outAlpha,
                    outAlpha);
            }
        }

        struct IntColor {
            public int Alpha { get; }
            public int Red { get; }
            public int Green { get; }
            public int Blue { get; }

            public IntColor(Color color) {
                Alpha = (int)(color.Alpha * 225);
                Red = (int)(color.Red * 225);
                Green = (int)(color.Green * 225);
                Blue = (int)(color.Blue * 225);
            }
        }
    }
}